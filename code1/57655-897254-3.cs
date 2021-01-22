    List<List<string>> quotedListLines = MyRegEx.GetMatchesArrayPerLine(a);
    foreach (List<string> line in quotedListLines)
    {
        Console.WriteLine("----LINE---");
        foreach (string quotedText in line)
            Console.WriteLine(quotedText);
    }
