    class Program
    {
        const int counter = 1024 * 1024;
        static void Main(string[] args)
        {
            for (int i = 0; i < counter; ++i)
            {
                Console.WriteLine(i);
            }
    
            for (int i = 0; i < counter; i++)
            {
                Console.WriteLine(i);
            }
        }
    }
