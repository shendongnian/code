    public static Regex regex = new Regex("Length:\\s*(\\d+)", RegexOptions.CultureInvariant | RegexOptions.Compiled);
    static void Main()
    {
        var testValue = "Offset: 23,123 Length: 504";
        var match = regex.Match(testValue);
        if (match.Success)
        {
            Console.WriteLine($"Length is {match.Groups[1].Value}");
        }
    }
