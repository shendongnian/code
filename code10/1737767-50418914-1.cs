    public static class MyExtensions
    {
        public static string ModifyString(this string s, Func<string, string> f)
        {
            return f(s);
        }
    }
