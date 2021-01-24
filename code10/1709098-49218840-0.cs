    static void Main(string[] args)
    {
        string input = "<Param8>1</Param8>";
        Regex rx = new Regex(@"<Param8>(\d+)</Param8>");
        var res = rx.Match(input);
        Console.WriteLine(res.Groups[1].Value);
    }
