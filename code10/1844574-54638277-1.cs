    Double a;
    String input = Console.ReadLine();
    if (!Double.TryParse(input, out a))
    {
         Console.WriteLine("That was not a number...");
    }
