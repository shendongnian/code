    class Foo
    {
        private int count = 0;
        private readonly object sync = new object();
        public void TrySomething()    
        {
            lock(sync)
                count++;
        }
    }
 
