    private Regex CSharpShortRegex = new Regex(@"""(?<constant>([^""]|(\\.))*)"".Localize\(\)");
    void Run()
    {
        string x = string.Format("{0},{1}",
            "\"Having \\\"Two\\\" On The Same Line\".Localize()",
            "\"Is Tricky For regex\".Localize()");
        foreach (Match match in CSharpShortRegex.Matches(x))
            Console.WriteLine(match.Groups["constant"].Value);
    }
