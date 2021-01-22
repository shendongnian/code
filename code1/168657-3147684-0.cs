    namespace ExtensionMethods
    {
        public static class MyExtensions
        {
            public static int CopyTo<T>(this Base source, ref T dest)
            {
              // Use reflection to cycle public properties and if you find equally named ones, copy them.
            }
        }   
    }
