    Double a;
    do 
    {
        String input = Console.ReadLine();
        if (Double.TryParse(input, out a))
        {
            break; 
        }
        Console.WriteLine("That was not a number... Try again. ");
    }
