    public static class MyExtensions
    {
        public static string ModifyString(this string s, Func<string, TResult> f)
        {
            return f(s);
        }
    }
