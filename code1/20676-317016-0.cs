    public static List<string> SplitCSV(string line)
    {
        if (string.IsNullOrEmpty(line))
            throw new ArgumentException();
        List<string> result = new List<string>();
        bool inQuote = false;
        StringBuilder val = new StringBuilder();
        // parse line
        foreach (var t in line.Split(','))
        {
            int count = t.Count(c => c == '"');
            if (count > 2 && !inQuote)
            {
                inQuote = true;
                val.Append(t);
                val.Append(',');
                continue;
            }
            if (count > 2 && inQuote)
            {
                inQuote = false;
                val.Append(t);
                result.Add(val.ToString());
                continue;
            }
            if (count == 2 && !inQuote)
            {
                result.Add(t);
                continue;
            }
            if (count == 2 && inQuote)
            {
                val.Append(t);
                val.Append(',');
                continue;
            }
        }
        // remove quotation
        for (int i = 0; i < result.Count; i++)
        {
            string t = result[i];
            result[i] = t.Substring(1, t.Length - 2);
        }
        return result;
    }
