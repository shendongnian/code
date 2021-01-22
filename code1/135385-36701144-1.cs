    using System.Collections.Generic;
    using System.Runtime.CompilerServices;
    public static class StaticLocal<T>
    {
        static StaticLocal()
        {
            dictionary = new Dictionary<int, Dictionary<string, Access>>();
        }
        public class Access
        {
            public T Value { get; set; }
            public Access(T value)
            {
                Value = value;
            }
    
        }
        public static Access Init(T value, [CallerFilePath]string callingFile = "",
                                           [CallerMemberName]string callingMethod = "",
                                           [CallerLineNumber]int lineNumber = -1)
        {
            var secondKey = callingFile + '.' + callingMethod;
            if (!dictionary.ContainsKey(lineNumber))
                dictionary.Add(lineNumber, new Dictionary<string, Access>());
            if (!dictionary[lineNumber].ContainsKey(secondKey))
                dictionary[lineNumber].Add(secondKey, new Access(value));
            return dictionary[lineNumber][secondKey];
        }
        private static Dictionary<int, Dictionary<string, Access>> dictionary;
    }
