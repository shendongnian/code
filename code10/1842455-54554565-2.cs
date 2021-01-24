        Console.Clear();
        // Appending String in a loop can be time consuming
        // We have a special type for this - StringBuilder
        StringBuilder calculation = new StringBuilder();
        double sum = 0.0;
        foreach (string arg in args)
        {
            if (calculation.Length > 0)
                calculation.Append(" + "); 
            calculation.Append(arg);
            sum = sum + Convert.ToDouble(arg);
        }
        Console.WriteLine($"{sum} {calculation.ToString()}");
