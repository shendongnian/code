    class Program
    {
        static Foo foo = null;
    
        static void Main(string[] args)
        {
            foo = new Foo();
    
            using (foo)
            {
                SomeAction();
            }
    
            Console.Read();
        }
    
        static void SomeAction()
        {
            foo = null;
        }
    }
    
    class Foo : IDisposable
    {
        #region IDisposable Members
    
        public void Dispose()
        {
            Console.WriteLine("disposing...");
        }
    
        #endregion
    }
