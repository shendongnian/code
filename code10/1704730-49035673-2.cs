    class A
    {
        public int TEST2 = 10;
    }
    class Program
    {
        public static void Main(string[] args)
        {
            // instance of class A
            A a = new A();
            Console.WriteLine("First: " + a.TEST2);
            a.TEST2 = 5;
            Console.WriteLine("Last: " + a.TEST2);
            
            int something = a.TEST2;
            Console.WriteLine("Something: " + something);
        }
