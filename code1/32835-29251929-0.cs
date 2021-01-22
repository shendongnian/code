    public static IEnumerable<string> SplitAndKeep(string s, params string[] delims)
    {
        var rows = new List<string>() { s };
        foreach (string delim in delims)//delimiter counter
        {
            for (int i = 0; i < rows.Count; i++)//row counter
            {
                int index = rows[i].IndexOf(delim);
                if (index > -1
                    && rows[i].Length > index + 1)
                {
                    string leftPart = rows[i].Substring(0, index + delim.Length);
                    string rightPart = rows[i].Substring(index + delim.Length);
                    rows[i] = leftPart;
                    rows.Insert(i + 1, rightPart);
                }
            }
        }
        return rows;
    }
