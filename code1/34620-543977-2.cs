    class Test
    {
        void M (void) // Fits Action delegate
        {
        }
        int M (int) // Fits Func<int,int> delegate
        {
            return 5;
        }
        void Test()
        {
            M.Exec(); // UHOH!!! Which Exec to resolve to ???
        }
    }
    public static class Extensions
    {
        public static void Exec(this Action action) { }
        public static void Exec(this Func<int, int> func) { }
    }
