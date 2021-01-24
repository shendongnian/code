    static bool NotNullOrEmpty(string s) => !String.IsNullOrEmpty(s);
    static string SelectSelf(string s) => s;
    static bool StartsWithX(string s) => s.StartsWith("x");
    public static System.Collections.Generic.IEnumerable<string> Test(System.Collections.Generic.IList<string> values)
    {
        var listX = values.Where(NotNullOrEmpty).Select(SelectSelf).Where(StartsWithX);
        return listX;
    }
