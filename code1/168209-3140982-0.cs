    public static List<int> StringToList(string stringToSplit, char splitDelimiter)
    {
        int i;
        return stringToSplit.Split(splitDelimiter)
            .Where(str => int.TryParse(str, out i))
            .Select(str => int.Parse(str))
            .ToList();
    }
