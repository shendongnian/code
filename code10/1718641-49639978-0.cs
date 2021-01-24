    string input = Console.ReadLine();
    int parsed;
    while (!int.TryParse(input, out parsed))
    {
         Console.WriteLine("Please enter a number!");
         input = Console.ReadLine();
    }
    //do something with parsed
