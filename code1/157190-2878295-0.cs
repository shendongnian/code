    String text = "<a href=\"link.php\">test</a>";
    Regex rx = new Regex("<a[^>]+?>(.*?)</a>");
    // Find matches.
    MatchCollection matches = rx.Matches(text);
    // Report the number of matches found.
    Console.WriteLine("{0} matches found. \n", matches.Count);
    // Report on each match.
    foreach (Match match in matches)
    {
        Console.WriteLine(match.Value);
        Console.WriteLine("Groups:");
        foreach (var g in match.Groups)
        {
            Console.WriteLine(g.ToString());
        }
    }
    Console.ReadLine();
