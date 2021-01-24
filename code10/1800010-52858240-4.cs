        double amount = double.Parse(Console.ReadLine());
        double cents5 = amount / 0.05;
        if (cents5 - Convert.ToInt32(cents5) == 0)
        {
            Console.WriteLine(cents5 + " * 5 cents");
        }
    
        Console.WriteLine(cents5 + "  " + Convert.ToInt32(cents5));
