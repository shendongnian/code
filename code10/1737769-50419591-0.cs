    public static class MyExtensions
    {
        public static TResult ModifyString<TResult>(this string s, Func<string, TResult> f)
        {
            return f(s);
        }
    }
