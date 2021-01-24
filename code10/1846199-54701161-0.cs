        double price = 0;
        double input = 0;
        const double _TAX = .065;
        double tax;
        double total;
        int count = 1;
        while (true)
        {
            Console.Write("Item #{0}   Enter Price: $", count);
            input = Convert.ToDouble(Console.ReadLine());
            if (input == - 1)
            {
                break;
            }
            count++
            price += input;
        }
        Console.WriteLine("\n   Items:   {0}", count);
