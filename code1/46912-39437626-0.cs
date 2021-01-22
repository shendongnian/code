    class Program
    {
        static void Main(string[] args)
        {
            a a1 = new b();  
            a1.print();  
        }
    }
    class a
    {
        public a()
        {
            Console.WriteLine("base class object initiated");
        }
        public void print()
        {
            Console.WriteLine("base");
        }
    }
    class b:a
    {
        public b()
        {
            Console.WriteLine("child class object");
        }
        public void print1()
        {
            Console.WriteLine("derived");
        }
    }
