    class Program
    {
        static void Main(string[] args)
        {
            var j = returny();
            j.blah();
        }
        private static y returny()
        {
            return new y();
        }
    }
    class x
    {
    }
    class y : x
    {
        public void blah() { }
    }
