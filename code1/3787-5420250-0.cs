    public static class NullableParse
    {
        public static Nullable<T> ParseBy<T>(this string input, Func<string, T> parser)
            where T : struct
        {
            try
            {
                return parser(input);
            }
            catch (Exception exc)
            {
                return null;
            }
        }
        public delegate bool TryParseDelegate<T>(string input, out T result);
        public static Nullable<T> ParseBy<T>(this string input, TryParseDelegate<T> parser)
            where T : struct
        {
            T t;
            if (parser(input, out t)) return t;
            return null;
        }
    }
