    public List<int> StringToList(string stringToSplit, char delimiter)
    {
        // Notice: since string.Split returns a string[], and string[] implements
        // IEnumerable<string>, so the ParseAll extension method can be called on it.
        return stringToSplit.Split(delimiter).ParseAll<int>(int.TryParse).ToList();
    }
