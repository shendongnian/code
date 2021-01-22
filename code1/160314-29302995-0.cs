    class Program
    {
        static void Main(string[] args)
        {
            var r = new Random();
            foreach(var i in Enumerable.Range(0,100))            
                new Derived(r).Printer();            
            Console.Read();
        }
    }
    public class Base
    {
        private Random r;
        public Base(Random r) { this.r = r; }
        protected void Print()
        {
            Console.WriteLine(r.Next(1, 10000));
        }
    }
    public class Derived : Base
    {
        public Derived(Random r) : base(r) { }
        public void Printer()
        {
            base.Print();
        }
    }
