    static class Ident
    {
        static int index = -1;
        static int Index
        {
            get
            {
                return Interlocked.Increment(ref index);
            }
        }
        private static class Type<T>
        {
            public static int id = Index;
        }
        public static int TypeIndex<T>()
        {
            return Type<T>.id;
        }
    } 
