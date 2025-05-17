namespace ConsoleApp8;
class Program
{
//1
class Human
{
    public string Name { get; set; }
    public int Age { get; set; }

    public Human(string name, int age)
    {
        Name = name;
        Age = age;
    }

    public virtual void Info()
    {
        Console.WriteLine($"Name: {Name}, Age: {Age}");
    }
}

class Builder : Human
{
    public string Tool { get; set; }

    public Builder(string name, int age, string tool) : base(name, age)
    {
        Tool = tool;
    }

    public override void Info()
    {
        base.Info();
        Console.WriteLine($"Profession: Builder, Tool: {Tool}");
    }
}

class Sailor : Human
{
    public string Ship { get; set; }

    public Sailor(string name, int age, string ship) : base(name, age)
    {
        Ship = ship;
    }

    public override void Info()
    {
        base.Info();
        Console.WriteLine($"Profession: Sailor, Ship: {Ship}");
    }
}

class Pilot : Human
{
    public string Plane { get; set; }

    public Pilot(string name, int age, string plane) : base(name, age)
    {
        Plane = plane;
    }

    public override void Info()
    {
        base.Info();
        Console.WriteLine($"Profession: Pilot, Plane: {Plane}");
    }
}

//2
class Passport
{
    public string FullName { get; set; }
    public string Nationality { get; set; }
    public string PassportNumber { get; set; }

    public Passport(string fullName, string nationality, string passportNumber)
    {
        FullName = fullName;
        Nationality = nationality;
        PassportNumber = passportNumber;
    }

    public virtual void ShowInfo()
    {
        Console.WriteLine($"Full Name: {FullName}, Nationality: {Nationality}, Passport #: {PassportNumber}");
    }
}

class ForeignPassport : Passport
{
    public string ForeignNumber { get; set; }
    public List<string> Visas { get; set; }

    public ForeignPassport(string fullName, string nationality, string passportNumber, string foreignNumber, List<string> visas)
        : base(fullName, nationality, passportNumber)
    {
        ForeignNumber = foreignNumber;
        Visas = visas;
    }

    public override void ShowInfo()
    {
        base.ShowInfo();
        Console.WriteLine($"Foreign Passport #: {ForeignNumber}, Visas: {string.Join(", ", Visas)}");
    }
}

//3
class Animal
{
    public string Name { get; set; }
    public string Feature { get; set; }

    public Animal(string name, string feature)
    {
        Name = name;
        Feature = feature;
    }

    public virtual void Show()
    {
        Console.WriteLine($"Animal: {Name}, Feature: {Feature}");
    }
}

class Tiger : Animal
{
    public Tiger(string name, string feature) : base(name, feature) { }
}

class Crocodile : Animal
{
    public Crocodile(string name, string feature) : base(name, feature) { }
}

class Kangaroo : Animal
{
    public Kangaroo(string name, string feature) : base(name, feature) { }
}

//4
abstract class Figure
{
    public abstract double Area();
}

class Rectangle : Figure
{
    public double Width { get; set; }
    public double Height { get; set; }

    public Rectangle(double width, double height)
    {
        Width = width;
        Height = height;
    }

    public override double Area() => Width * Height;
}

class Circle : Figure
{
    public double Radius { get; set; }

    public Circle(double radius)
    {
        Radius = radius;
    }

    public override double Area() => Math.PI * Radius * Radius;
}

class Triangle : Figure
{
    public double Base { get; set; }
    public double Height { get; set; }

    public Triangle(double b, double height)
    {
        Base = b;
        Height = height;
    }

    public override double Area() => 0.5 * Base * Height;
}

class Trapezoid : Figure
{
    public double Base1 { get; set; }
    public double Base2 { get; set; }
    public double Height { get; set; }

    public Trapezoid(double b1, double b2, double height)
    {
        Base1 = b1;
        Base2 = b2;
        Height = height;
    }

    public override double Area() => 0.5 * (Base1 + Base2) * Height;
}

//5
class InvalidAgeException : ArgumentException
{
    public InvalidAgeException(string message) : base(message) { }
}

class Person
{
    private int age;
    public int Age
    {
        get => age;
        set
        {
            if (value < 0 || value > 120)
                throw new InvalidAgeException("Age must be between 0 and 120.");
            age = value;
        }
    }

    public string Name { get; set; }

    public Person(string name, int age)
    {
        Name = name;
        Age = age;
    }
}

class Program
{
    static void Main(string[] args)
    {
        //1
        Builder b = new Builder("John", 35, "Hammer");
        Sailor s = new Sailor("Tom", 40, "Titanic");
        Pilot p = new Pilot("Kate", 29, "Boeing 747");
        b.Info(); s.Info(); p.Info();

        //2
        ForeignPassport fp = new ForeignPassport("Anna Smith", "USA", "A123456", "FP78910", new List<string> { "UK", "Canada" });
        fp.ShowInfo();

        //3
        Animal tiger = new Tiger("Tiger", "Fast and strong");
        Animal croc = new Crocodile("Crocodile", "Strong jaws");
        Animal kangaroo = new Kangaroo("Kangaroo", "Can jump high");
        tiger.Show(); croc.Show(); kangaroo.Show();

        //4
        Figure[] figures = {
            new Rectangle(4, 5),
            new Circle(3),
            new Triangle(6, 2),
            new Trapezoid(3, 5, 4)
        };
        foreach (var fig in figures)
        {
            Console.WriteLine($"Area: {fig.Area():F2}");
        }

        //5 
        try
        {
            Person person1 = new Person("Mark", 25);
            Person person2 = new Person("Lucy", 130); 
        }
        catch (InvalidAgeException ex)
        {
            Console.WriteLine($"Exception: {ex.Message}");
        }
    }
}

static void Main(string[] args)
    {
        
    }
}
