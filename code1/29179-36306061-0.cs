    namespace System.Collections.Generic
    {
        static class List
        {
            public static List<T> Singleton<T>(T value) => new List<T>(1) { value };
        }
    }
