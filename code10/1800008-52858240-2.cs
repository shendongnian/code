        double amount = double.Parse(Console.ReadLine());
        double cents5 = Math.Round(amount / 0.05, 2);
        if (cents5 - (int)cents5 == 0)
        {
            Console.WriteLine(cents5 + " * 5 cents");
        }
    
        Console.WriteLine(cents5 + "  " + (int)cents5);
