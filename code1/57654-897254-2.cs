    /// This will help you store the data in a list in a more meaningful way, 
    /// so that you are able to organize the data per line
    /// Returns all the quoted text per line in a list of lines
    public static List<List<string>> GetMatchesArrayPerLine(String inputString)
    {
        // Matches var matches = new Array( ... )
        Regex r = new Regex("(var matches = new Array\\([^\\)]*\\);)",
            RegexOptions.IgnoreCase | RegexOptions.Compiled | RegexOptions.Multiline);
    
        string arrayString = r.Match(inputString).Groups[0].Value;
    
        List<string> lineList = new List<string>();
    
        // Matches all the lines and stores them in lineList one line per item. For e.g.
        // "125","1.FC Nurnberg - TSV 1860 Munich", ...
        // "126","FC Ingolstadt 04 - TuS Koblenz", ...
        r = new Regex("\n(.*)", RegexOptions.IgnoreCase | RegexOptions.Compiled | RegexOptions.Multiline);
        for (Match m = r.Match(arrayString); m.Success; m = m.NextMatch())
        {
            lineList.Add(m.Groups[1].Value);
        }
    
        List<List<string>> quotedListPerLine = new List<List<string>>();
        
        // Matches the quoted text per line. 
        // This will help you store data in an organised way rather than just a list of values
        // Similar to a 2D array
        // quotedListPerLine[0] = List<string> containing { "125", "1.FC Nurnberg - TSV 1860 Munich", ... }
        // quotedListPerLine[1] = List<string> containing { "126","FC Ingolstadt 04 - TuS Koblenz", ... }
        r = new Regex("\"([^\"]+)\"", RegexOptions.IgnoreCase | RegexOptions.Compiled);
        foreach (string line in lineList)
        {
            List<string> quotedList = new List<string>();
            for (Match m = r.Match(line); m.Success; m = m.NextMatch())
            {
                quotedList.Add(m.Groups[1].Value);
            }
            quotedListPerLine.Add(quotedList);
        }
    
        return quotedListPerLine;
    }
