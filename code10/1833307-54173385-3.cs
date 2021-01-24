    static void Main(string[] args)
    {
        Student newStudent = AddStudent();
        Console.WriteLine(newStudent); //calls .ToString()
        Console.ReadKey();
    }
    private static Student AddStudent()
    {
        Student s = new Student();
        Console.WriteLine("Enter first name");
        s.FirstName = Console.ReadLine();
        Console.WriteLine("Enter last Name");
        s.LastName = Console.ReadLine();
        //etc.
        Console.WriteLine("Enter Street");
        string Street = Console.ReadLine();
        Console.WriteLine("Enter City");
        string City = Console.ReadLine();
        Console.WriteLine("Enter Country");
        string Country = Console.ReadLine();
        Address a = new Address(Street, City, Country);
        s.StudentAddress = a;
        return s;
    }
