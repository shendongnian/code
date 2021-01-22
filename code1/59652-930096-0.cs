    string line = Console.ReadLine();
    int value;
    if (int.TryParse(line, out value))
    {
        Console.WriteLine("Successfully parsed value: {0}", value);
    }
    else
    {
        Console.WriteLine("Invalid number - try again!");
    }
