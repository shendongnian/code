    public static class Extensions {
        public static T? ParseAs<T>(this string str) where T : struct {
            T val;
            return GenericHelper<T>.TryParse(str, out val) ? val : default(T?);
        }
        public static T ParseAs<T>(this string str, T defaultVal) {
            T val;
            return GenericHelper<T>.TryParse(str, out val) ? val : defaultVal;
        }
        private static class GenericHelper<T> {
            public delegate bool TryParseFunc(string str, out T result);
            private static TryParseFunc tryParse;
            public static TryParseFunc TryParse {
                get {
                    if (tryParse == null)
                        tryParse = Delegate.CreateDelegate(
                            typeof(TryParseFunc), typeof(T), "TryParse") as TryParseFunc;
                    return tryParse;
                }
            }
        }
    }
