    class Program
        {
            static void Main(string[] args)
            {
                int x = 4;
                test(x);
            }
    
            static void test(object o)
            {
                Console.WriteLine(o.ToString());
            }
        }
