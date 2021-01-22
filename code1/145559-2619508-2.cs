    struct Mutable
    {
        public static int Sum = 0;
        public int x;
        public Mutable(int x) { this.x = x; }
        public void Total() { Sum += x; }
    }
    class Container
    {
        public Mutable Field;
        public Mutable Property { get; set; }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Container c = new Container();
            c.Field = new Mutable(1);
            c.Property = new Mutable(2);
            c.Field.Total();
            c.Property.Total();
            Console.Out.WriteLine(Mutable.Sum);
        }
    }
