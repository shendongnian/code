    public static class StaticLocal<T>
    {
        static StaticLocal()
        {
            dictionary = new Dictionary<string, Dictionary<string, Dictionary<int, Access>>>();
        }
        public class Access
        {
            public T Value { get; set; }
        }
        public static Access Init(T value, [CallerFilePath]string callingFile = "",
                                           [CallerMemberName]string callingMethod = "",
                                           [CallerLineNumber]int lineNumber = -1)
        {
            if (!dictionary.ContainsKey(callingFile))
                dictionary.Add(callingFile, new Dictionary<string, Dictionary<int, Access>>());
            if (!dictionary[callingFile].ContainsKey(callingMethod))
                dictionary[callingFile].Add(callingMethod, new Dictionary<int, Access>());
            if (!dictionary[callingFile][callingMethod].ContainsKey(lineNumber))
            {
                dictionary[callingFile][callingMethod].Add(lineNumber, new Access());
                dictionary[callingFile][callingMethod][lineNumber].Value = value;
            }
            return dictionary[callingFile][callingMethod][lineNumber];
        }
        private static Dictionary<string, Dictionary<string, Dictionary<int, Access>>> dictionary;
    }
