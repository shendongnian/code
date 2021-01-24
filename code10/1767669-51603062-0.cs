    static void Main(string[] args)
    {
        var inputComma = "12,345";
        var inputColon = "98:76";
        Regex regexComma = new Regex(@"^\d{2},\d{3}$");
        Regex regexColon = new Regex(@"^\d{2}:\d{2}$");
        var matchComma = regexComma.Match(inputComma);
        if (matchComma.Success)
        {                
            Console.WriteLine(inputComma);
        }
        Console.WriteLine();
        var matchColon = regexColon.Match(inputColon);
        if (matchColon.Success)
        {
            Console.WriteLine(inputColon);
        }
        Console.ReadLine();
    }
