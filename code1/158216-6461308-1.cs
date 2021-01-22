    class Test
    {
        private ConcurrentDictionary<int, Class1> dictionary = new ConcurrentDictionary<int, Class1>();
    
        public void TestIt()
        {
            foreach (var foo in dictionary.Values)
            {
                foo.Increment();
            }
        }
    
        public void TestItParallel()
        {
            Parallel.ForEach(dictionary.Values,x=>x.Increment() );
        }
    
    }
