    class Program
    {
        static void Main(string[] args)
        {
    
            using (Foo foo = new Foo())
            {
                SomeAction(foo);
            }
    
            Console.Read();
        }
    
        static void SomeAction(Foo foo)
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
