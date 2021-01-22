    string input = "foo.bar.foobar";
    int lastDotPosition = input.LastIndexOf('.');
    if (lastDotPosition == -1)
    {
        Console.WriteLine("No dot found");
    }
    else if (lastDotPosition == input.Length - 1)
    {
        Console.WriteLine("Last dot found at the very end");
    }
    else
    {
        string firstPart = input.Substring(0, lastDotPosition);
        string lastPart = input.Substring(lastDotPosition + 1);
        Console.WriteLine(firstPart);
        Console.WriteLine(lastPart);
    }
