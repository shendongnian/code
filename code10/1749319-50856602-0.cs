    private static void DisplaRegexSplit(string test)
    {
        Console.WriteLine(test);
        var collection = Regex.Matches(test, @"(\(?-?\p{Sc}?\d+(,\d{3})*(\.\d+)*\)?)");
        System.Console.WriteLine("{0} Matches", collection.Count);
        foreach(Match match in collection)
        {
           Console.WriteLine(match.Value);
        }
    }
