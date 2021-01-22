    string text = "123":
    int value;
    if (int.TryParse(text, out value))
    {
        Console.WriteLine("Parsed successfully: {0}", value);
    }
    else
    {
        Console.WriteLine("Unable to parse text as an integer");
    }
