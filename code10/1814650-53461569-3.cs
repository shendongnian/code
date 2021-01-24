    List<string> Unique(string lines1 ,string lines2,  char[] separators)
    {    
    string[] words1 = lines1.Split(separators, StringSplitOptions.RemoveEmptyEntries);
    string[] words2 = lines2.Split(separators, StringSplitOptions.RemoveEmptyEntries);
    return words1.Except(words2).ToList();
    }
