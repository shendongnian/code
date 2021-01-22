    class Program
    {
        class A : ICloneable
        {
            public int X = 2;
            public A()
            {
                Console.WriteLine("hiya");
                X = 1;
            }
    
            public object Clone()
            {
                A a = MemberwiseClone() as A;
     
                return a;
            }
        }
    
        static void Main(string[] args)
        {
            A a = new A();
            a.X = 3;
            A b = a.Clone() as A;
        }
    }
