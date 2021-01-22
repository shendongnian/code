    public static class Primitive
    {
        public static DateTime? TryParseExact(string text, string format, IFormatProvider formatProvider = null, DateTimeStyles? style = null)
        {
            DateTime result;
            if (DateTime.TryParseExact(text, format, formatProvider, style ?? DateTimeStyles.None, out result))
                return result;
            return null;
        }
        public static TResult? TryParse<TResult>(string text) where TResult : struct
        {
            TResult result;
            if (Delegates<TResult>.TryParse(text, out result))
                return result;
            return null;
        }
        public static bool TryParse<TResult>(string text, out TResult result) => Delegates<TResult>.TryParse(text, out result);
        public static class Delegates<TResult>
        {
            private delegate bool TryParseDelegate(string text, out TResult result);
            private static readonly TryParseDelegate _parser = (TryParseDelegate)Delegate.CreateDelegate(typeof(TryParseDelegate), typeof(TResult), "TryParse");
            public static bool TryParse(string text, out TResult result) => _parser(text, out result);
        }
    }
