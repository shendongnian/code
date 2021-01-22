    class Test
    {
        public int n;
        public int i { get; set; }
        public void Setter(out int i)
        {
            i = 100;
        }
        public Test()
        {
            Setter(out n); // This is OK
            Setter(out i); // ERROR: A property or indexer may not be passed 
                           // as an out or ref parameter
        }
    }
