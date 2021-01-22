    public class OuterClass
    {
        public InnerClass Ic { get; set; }
    
        public class InnerClass
        {
            public InnerClass()
            {
                Foo = 42;
            }
    
            public int Foo { get; set; }
        }
    }
    
    public class Program
    {
        static void Main()
        {
            Console.WriteLine(new OuterClass().Ic.Foo);
        }
    }
