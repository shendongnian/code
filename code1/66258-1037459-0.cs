    private static void RegexGetDates()
    {
        string fileText = File.ReadAllText("..\\..\\Data\\RegexSample2.txt");
    
        List<string> matchesList = MyRegEx.GetMatchedDates(fileText);
        foreach (string s in matchesList)
            Console.WriteLine(s);
    }
