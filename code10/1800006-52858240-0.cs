        decimal amount = decimal.Parse(Console.ReadLine());
        decimal cents5 = amount / 0.05m; //<-- use m after 0.05 to mark it as decimal literal
        if (cents5 - (int)cents5 == 0)
        {
            Console.WriteLine(cents5 + " * 5 cents");
        }
        
        Console.WriteLine(cents5 + "  " + (int)cents5);
