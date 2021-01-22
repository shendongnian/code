    namespace System.Collections.Generic
    {
        public static class List
        {
            public static List<T> Create<T>(T value) => new List<T>(1) { value };
        }
    }
