    class Program
    {
        public void Foo() { }
    
        static void Main() 
        {}
    
        static void Method1()
        {
            var x = new Program();
            x.Foo();
        }
    
        static void Method2()
        {
            new Program().Foo();
        }
    }
