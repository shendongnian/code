    class Program
    {
        static void Main(string[] args)
        {
            for (int  i = 0; i < Foo(); i++)
            {
                Console.WriteLine(i);
                i++;
                
            }
            Console.Read();
        }
        private static int Foo()
        {
            return 20;
        }
