    class Program
    {
        static IEnumerable<int> meth1()
        {
            try
            {
                Console.WriteLine("Enter");
                yield return 1;
                yield return 2;
                yield return 3;
            }
            finally
            {
                Console.WriteLine("Exit");
            }
        }
        static IEnumerable<int> meth2()
        {
            try
            {
                Console.WriteLine("Enter");
                return new int[] { 1, 2, 3 };
            }
            finally
            {
                Console.WriteLine("Exit");
            }
        }
        static public void Main()
        {
            foreach (int i in meth1())
            {
                Console.WriteLine("In");
            }
            Console.WriteLine();
            foreach (int i in meth2())
            {
                Console.WriteLine("In");
            }   
        }
    }
