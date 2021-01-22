    int? TryParse(string s)
    {
        int i;
        return int.TryParse(s, out i) ? (int?)i : (int?)null;
    }
    IEnumerable<int> XValuesFromFile(string filename)
    {
        return from line in ReadLines(filename)
               let start = line.Substring(3,3)
               let parsed = TryParse(start)
               where parsed != null
               select parsed.GetValueOrDefault();
    }
