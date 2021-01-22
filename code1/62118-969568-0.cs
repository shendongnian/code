    public static string SubstringBefore(this string s, char value) {
        if(string.IsNullOrEmpty(s)) return s;
        int i = s.IndexOf(value);
        return i > 0 ? s.Substring(0,i) : s;
    }
    public static string SubstringAfter(this string s, char value) {
        if (string.IsNullOrEmpty(s)) return s;
        int i = s.IndexOf(value);
        return i >= 0 ? s.Substring(i + 1) : s;
    }
