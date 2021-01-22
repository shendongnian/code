    public static IEnumerable<string> ReplaceAll
        (this IEnumerable<string> myList, string toReplace, string replaceWith)
    {
        return toReplace.Select(x => x == toReplace ? replaceWith : x);
    }
