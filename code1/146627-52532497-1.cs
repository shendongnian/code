     class Clsparent
    {
        public Clsparent()
        {
            Console.WriteLine("This is Clsparent class constructor");
        }
        public Clsparent(int a, int b)
        {
            Console.WriteLine("a value is=" + a + " , b value is=" + b);
        }
    }
    class Clschild : Clsparent
    {
        public Clschild() : base(3, 4)
        {
            Console.WriteLine("This is Clschild class constructor");
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Clschild objclschild = new Clschild();
            Console.Read();
        }
    }
