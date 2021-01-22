    class Program
    {
        static void Main(string[] args)
        {
            
            Add(3, 4,3);
        }
        public static void Add(int FN, int SN)
        {
            Console.WriteLine("Total is {0}", FN + SN);
        }
        public static void Add(int FN, int SN, int TN)
        {
            Console.WriteLine("Total is {0}", FN + SN + TN); 
        }
    }
