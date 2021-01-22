    class Program
    {
        static void Main(string[] args)
        {
            var foo = new Foo<int>();
            try
            {
                Console.WriteLine("Calling function");
                foo.DoStuff(5);
            }
            catch(Exception ex)
            {
                Console.WriteLine("Caught exception: " + ex.ToString());
            }
            finally
            {
                Console.WriteLine("In finally block");
            }
        }
    }
    
    class Foo<T>
    {
        private Func<T, object> pony;
        
        public Foo()
        {
            this.pony = m =>
            {
                throw new DivideByZeroException("Exception!");
            };
        }
        
        public object DoStuff(T o)
        {
            return this.pony.Invoke(o);
        }
    }
