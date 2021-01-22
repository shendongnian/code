    class A
    {
        // note that this field is private
        string PrivateString = string.Empty;
        // protected field
        protected string ProtectedString = string.Empty;
    }
    
    class B : A { }
   
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("B Fields:");
            B b = new B();
            b.GetType()
                .GetFields(BindingFlags.NonPublic | BindingFlags.Instance)
                .ToList()
                .ForEach(f => Console.WriteLine(f.Name));
    
            Console.WriteLine("A Fields:");
            A a = new A();
            a.GetType()
                .GetFields(BindingFlags.NonPublic | BindingFlags.Instance)
                .ToList()
                .ForEach(f => Console.WriteLine(f.Name));
    
        }
    }
