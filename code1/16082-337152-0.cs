    public class MyLockedResource : IDisposable
    {
        private MyLockedResource()
        {
            Console.WriteLine("initialize");
        }
    
        public void Dispose()
        {
            Console.WriteLine("dispose");
        }
    
        public delegate void RAII(MyLockedResource resource);
    
        static public void Use(RAII raii)
        {
            using (MyLockedResource resource = new MyLockedResource())
            {
                raii(resource);
            }
        }
    
        public void test()
        {
            Console.WriteLine("test");
        }
    }
