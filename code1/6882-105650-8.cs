    class Foo
    {
        private int count = 0;
        public void TrySomething()    
        {
            System.Threading.Interlocked.Increment(ref count);
        }
    }
