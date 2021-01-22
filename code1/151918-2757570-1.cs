    Regex arrayRegex = new Regex(@"Array[ \t]*\((.+)\)");
    Regex rowRegex = new Regex(@"\[([^\]]+)\] => Array \( ([^)]+)[ \t]*\)");
    Regex entryRegex = new Regex(@"\[([^\]]+)\] => ([^\]\[]+)");
    
    var rows = new List<SortedDictionary<string,string>>();
    var matches = arrayRegex.Matches(textToParse);
    foreach (Match match in matches)
    {
        if (match.Groups.Count != 2)
            throw new Exception("Invalid array");
        var rowsMactches = rowRegex.Matches(match.Groups[1].Value);
        foreach (Match rowMatch in rowsMactches)
        {
            var rowDict = new SortedDictionary<string, string>();
            if (rowMatch.Groups.Count != 3)
                throw new Exception("Invalid row");
            var entryMatches = entryRegex.Matches(rowMatch.Groups[2].Value);
            foreach (Match entryMatch in entryMatches)
            {
                if (entryMatch.Groups.Count != 3)
                    throw new Exception("Invalid entry");
                string key = entryMatch.Groups[1].Value;
                string val = entryMatch.Groups[2].Value;
                rowDict.Add(key, val);
            }
            rows.Add(rowDict);
        }
    }
    
    // use the first row to build the columns (N.B. we suppose all dictionaries have the same keys)
    var firstRow = rows.First();
    DataTable dt = new DataTable();
    foreach (string colName in firstRow.Keys)
    {
        dt.Columns.Add(colName);
    }
    foreach (var row in rows)
    {
        dt.Rows.Add(row.Values.Cast<object>().ToArray());
    }
