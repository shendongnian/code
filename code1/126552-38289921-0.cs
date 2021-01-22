    namespace AssemblyCSharp
    {
        public static class ExtentionMethod {
            public static bool TryGetValue<T, T2>(this Dictionary<T, T2> dict, string key, out T value) {
                return dict.TryGetValue(key, out value);
            }
        }
    }
