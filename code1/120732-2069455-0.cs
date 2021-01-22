    public struct Foo
    {
        public int x;
        public int X { get { return x; } set { x = value; } }
    }
    
    class Program
    {
        static void Main(string[] args)
        {
            Foo a;
            a.x = 10; // Valid
            
            Foo b;
            b.X = 10; // Invalid
        }
    }
