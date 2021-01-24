    private static string ReadLine(string writeMessage, bool parseAsInt = false)
    {
        Console.WriteLine(writeMessage);
        var line = Console.ReadLine();
        if (parseAsInt)
        {
            int parseInt = 0;
            int.TryParse(line, out parseInt);
            line = parseInt.ToString();
        }
        return line;
    }
