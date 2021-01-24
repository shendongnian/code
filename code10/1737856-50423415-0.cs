    static List<string> ExtractParts(string input)
    {
        string pattern = @"(?<=^|AND|OR)(?:[^()]+|.+?\(.+\).+?)(?=\s*AND|OR|$)";
        var matches = Regex.Matches(input, pattern);
        List<string> list = new List<string>();
        foreach (Match m in matches)
        {
            list.Add(m.Value.Trim());
        }
        return list;
    }
    static void Main(string[] args)
    {
        string input = @"Email=sample@sample.com OR "+
                       @"Something = '(101010101010 OR 0101010123 )'" +
                       @" AND Id = \""02341 - 21236 - 43497 - 123234\""";
        List<string> parts = ExtractParts(input);
        foreach (string part in parts)
        {
            Console.WriteLine(part);
        }
        Console.ReadLine();
    }
