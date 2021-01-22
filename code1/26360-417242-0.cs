    string foo = "Mimi loves Toto and Tata hate Mimi so Toto killed Tata";
    char[] separators = {' '};
    IList<string> capitalizedWords = new List<string>();
    string[] words = foo.Split(separators);
    foreach (string word in words)
    {
        char c = char.Parse(word.Substring(0, 1));
    
        if (char.IsUpper(c))
        {
            capitalizedWords.Add(word);
        }
    }
    
    foreach (string s in capitalizedWords)
    {
        Console.WriteLine(s);
    }
