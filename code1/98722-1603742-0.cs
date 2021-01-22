    static class Program
    {
        static void Main()
        {
            string s = ViaArray.SomeProp[1];
            string t = ViaIndexer.SomeProp[1];
        }
    }
    static class ViaArray
    {
        private static readonly string[] arr = { "abc", "def" };
        public static string[] SomeProp { get { return arr; } }
    }
    static class ViaIndexer
    {
        private static readonly IndexedType obj = new IndexedType();
        public static IndexedType SomeProp { get { return obj; } }
    }
    class IndexedType
    {
        private static readonly string[] arr = { "abc", "def" };
        public string this[int index]
        {
            get { return arr[index]; }
        }
    }
