    public static string Repeat(this string s, int count)
    {
        var _s = new System.Text.StringBuilder().Insert(0, s, count).ToString();
        return _s;
    }
