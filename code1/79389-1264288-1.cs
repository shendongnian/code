    static void AddToListIfNotEmpty(List<string> thelist, SqlString val)
    {
        string value = val.ToString().Trim();
        if (value != string.Empty && !thelist.Contains(value))
            thelist.Add(value);
    }
