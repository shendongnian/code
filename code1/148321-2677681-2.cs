    class A : IDisposable
    {
        public void Dispose()
        {
            Console.WriteLine("A Disposed");
        }
    }
    
    class B : IDisposable
    {
        public void Dispose()
        {
            Console.WriteLine("B Disposed");
        }
    }
