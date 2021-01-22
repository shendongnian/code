        class a
        {
            public void GetA()
            {
                Console.WriteLine("Hello World!");
            }
        }
    
        class b
        {
            // No explicit reference to class a of any kind.
            public void GetB(Action action)
            {
                action();
            }
        }
        
        class Program
        {
            static void Main(string[] args)
            {
                var a = new a();
                var b = new b();
    
                b.GetB(a.GetA);
            }
        }
