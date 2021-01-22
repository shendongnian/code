    public static class Extensions {
        public static T? ParseAs<T>(this string str) where T : struct {
            return ExtensionsGeneric<T>.ParseAs(str);
        }
    }
    internal static class ExtensionsGeneric<T> where T : struct {
        private delegate bool TryParser(string str, out T result);
        private static TryParser TryParseFunc;
        internal static T? ParseAs(string str) {
            if (TryParseFunc == null)
                TryParseFunc = (TryParser)Delegate.CreateDelegate(typeof(TryParser), typeof(T), "TryParse");
            T val;
            return TryParseFunc(str, out val) ? val : default(T?);
        }
    }
