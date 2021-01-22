    static List<string> FindNamesStartingWith(string startingText)
    {
        List<string> ret = new List<string>();
        foreach (string name in Names)
        {
            if (name.StartsWith(startingText))
            {
                ret.Add(name);
            }
        }
        return ret;
    }
