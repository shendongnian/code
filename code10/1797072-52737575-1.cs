    public static int MatchRank (HashSet<string> searchString, string value)
    {
        int result = 0;
        foreach (var item in searchString.OrderByDescending(x=>x.Length))
        {                
            if (value.StartsWith(item, StringComparison.Ordinal))
            {
                result = item.Length;
                break;
            }
            result = 0; // no match
        }
        return result;
    }
