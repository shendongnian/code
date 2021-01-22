    static User InputUser()
    {          
        User U = new User();
        Console.WriteLine("Please enter a User:");
        Console.WriteLine("User ID:");
        U.ID = int.Parse(Console.ReadLine());
        Console.WriteLine("Titel:");
        U.Titel = Console.ReadLine();
        Console.WriteLine("Name:");
        U.Name = Console.ReadLine();
        Console.WriteLine("Surname:");
        U.Surname = Console.ReadLine();
        Console.WriteLine("Telephone Number:");
        U.Telephone = int.Parse(Console.ReadLine());
        Console.WriteLine();
        return U;
    }
