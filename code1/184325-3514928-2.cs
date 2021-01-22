    using System;
    
    public class ThrowingDisposable : IDisposable
    {
        public string Name { get; set; }
        
        public string Bang { set { throw new Exception(); } }
        
        public ThrowingDisposable()
        {
            Console.WriteLine("Creating");
        }
        
        public void Dispose()
        {
            Console.WriteLine("Disposing {0}", Name);
        }
    }
    
    class Test
    {
        static void Main()
        {
            PropertiesInUsingBlock();
            WithObjectInitializer();
        }
        
        static void PropertiesInUsingBlock()
        {
            try
            {
                using (var x = new ThrowingDisposable())
                {
                    x.Name = "In using block";
                    x.Bang = "Ouch";
                }
            }
            catch (Exception)
            {
                Console.WriteLine("Caught exception");
            }
        }
        
        static void WithObjectInitializer()
        {
            try
            {
                using (var x = new ThrowingDisposable
                {
                    Name = "Object initializer",
                    Bang = "Ouch"
                })
                {
                    // Nothing
                }
            }
            catch (Exception)
            {
                Console.WriteLine("Caught exception");
            }
        }
    }
