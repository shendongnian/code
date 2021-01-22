    class Junk
    {
        public void Hello()
        {
            Console.WriteLine("Hello");
        }
    }
    
    class Program
    {
        static void Main(String[] args)
        {
            var a = new Junk();
            dynamic b = new Junk();
    
            a.Hello();
    
            b.Hello();
        }
    }
