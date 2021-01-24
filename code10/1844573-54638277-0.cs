    Double a = 0;
    try
    {
        a = Convert.ToDouble(Console.ReadLine()); 
    }
    catch (System.FormatException)
    {
        Console.WriteLine("that's not a number");
    }
