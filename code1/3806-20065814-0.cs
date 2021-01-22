    public static Nullable<T> ParseNullable<T>(string s, Func<string, T> parser) where T : struct
    {
        if (string.IsNullOrEmpty(s) || string.IsNullOrEmpty(s.Trim())) return null;
        else return parser(s);
    }
    static void Main(string[] args)
    {
        Nullable<int> i = ParseNullable("-1", int.Parse);
        Nullable<float> dt = ParseNullable("3.14", float.Parse);
    }
