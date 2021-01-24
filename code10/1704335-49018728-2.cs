    public static IEnumerable<bool> SecondContainsFirst(List<string> first, 
        List<string> second)
    {
        return second.Select(item => first.Any(item.Contains)).ToList();
    }
