    class Indexers
    {
        private string[] _strings = new [] {"A","B"};
        private int[] _ints = new[] { 1, 2 };
        public string[] Strings
        {
            get{ return _strings;}
        }
        public int[] Ints
        {
            get{ return _ints;}
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Indexers indexers = new Indexers();
            int a1 = indexers.Ints[0];
            string a2 = indexers.Strings[0];
        }
    }
