    class MyClass
    {
        Random r1 = new Random(1234); // You may even make it `static readonly`
        public void BadMethod()
        {
            // new Random everytime we call the method = bad (in most cases)
            Random r2 = new Random(1234); 
            for (int i = 0; i < 3; i++)
            {
                Console.WriteLine($"{i + 1}. {r2.Next()}");
            }
        }
        public void GoodMethod()
        {
            for (int i = 0; i < 3; i++)
            {
                Console.WriteLine($"{i+1}. {r1.Next()}");
            }
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            var m = new MyClass();
            m.BadMethod();
            m.BadMethod();
            m.GoodMethod();
            m.GoodMethod();
        }
    }
