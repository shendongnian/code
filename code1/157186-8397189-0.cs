    public static string ReplaceFirstOccurrence (string Source, string Find, string Replace)
    {
        int Place = Source.IndexOf(Find);
        string result = Source.Remove(Place, Find.Length).Insert(Place, Replace);
        return result;
    }
 
    public static string ReplaceLastOccurrence(string Source, string Find, string Replace)
    {
        int Place = Source.LastIndexOf(Find);
        string result = Source.Remove(Place, Find.Length).Insert(Place, Replace);
        return result;
    }
