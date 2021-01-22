    static IEnumerable<string> GetNames(IEnumerable<string> originalList, string fromName, string toName)
    {
        foreach (string name in originalList)
        {
            if (name.CompareTo(fromName) >= 0 && name.CompareTo(toName) <= 0)
                yield return name;
        }
    }
