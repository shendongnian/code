    private static string CommaQuibbling(IEnumerable<string> list)
    {
        IEnumerable<string> separators = GetSeparators(list.Count());
        var finalList = list.Zip(separators, (w, s) => w + s);
        return string.Concat("{", string.Join(string.Empty, finalList), "}");
    }
    
    private static IEnumerable<string> GetSeparators(int itemCount)
    {
        while (itemCount-- > 2)
            yield return ", ";
    
        if (itemCount == 1)
            yield return " and ";
    
        yield return string.Empty;
    }
