    class Program
    {
        static void Main(string[] args)
        {
            new Program().Foo("Bar");
        }
    
        public void Foo(string funcName)
        {
            GetType().GetMethod(funcName).Invoke(this, null);
        }
    
        public void Bar()
        {
            Console.WriteLine("bar");
        }
    }
