    static void Main()
    {
        var testStrings = new List<string>
        {
            "Has spaces      scattered          throughout  the   body    .",
            "      starts with spaces and ends with spaces         "
        };
        foreach (var testString in testStrings)
        {
            var result = ReplaceConsecutiveCharacters(testString, ' ', 4, "|");
            Console.WriteLine($"{testString} = {result}");
        }
        GetKeyFromUser("\nDone! Press any key to exit...");
    }
