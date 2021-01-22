    public static bool IsLessThan(this string a, string b) 
    { 
        return a.CompareTo(b) < 0; 
    } 
 
    public static bool IsGreaterThan(this string a, string b) 
    { 
        return a.CompareTo(b) > 0; 
    }
    // elsewhere...
    foo.IsLessThan(bar); // equivalent to foo < bar
