    static void Main(string[] args)
    {
        Person p1 = new Person();
        p1.Name = "d";
    
        if (Validate(p1))
        {
            Console.WriteLine("Valid");
        }
        else
        {
            Console.WriteLine("Invalid");
        }
    
        Console.WriteLine("Validation done");
        Console.ReadKey();
    }
