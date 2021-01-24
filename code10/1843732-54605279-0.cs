    int n = int.Parse(Console.ReadLine()); // Maybe use int.TryParse here
    decimal factorial = n;
    
    Console.Write(n);
    
    while (n > 1)
    {
    	n--;
    	factorial *= n;
    	Console.Write($" * {n}");
    }
    
    Console.WriteLine($" = {factorial}");
