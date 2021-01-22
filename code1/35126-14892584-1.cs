    //need to escape \s
    string pattern = "[^\\s\"']+|\"([^\"]*)\"|'([^']*)'";
    MatchCollection parsedStrings = Regex.Matches(line, pattern);
    for (int i = 0; i < parsedStrings.Count; i++)
    {
        //print parsed strings
        Console.Write(parsedStrings[i].Value + " ");
    }
    Console.WriteLine();
