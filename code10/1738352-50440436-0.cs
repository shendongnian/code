    string input = Console.ReadLine();
    int intValue;
    if (int.TryParse(input, out intValue))
    {
        Console.WriteLine(new string('*', intValue));
    }
