    public static void DeleteWordsFromText(string text, Regex p)
    {
    	Console.WriteLine($"---- {text} ----");
        Console.WriteLine(p.Replace(text, ""));
    }
