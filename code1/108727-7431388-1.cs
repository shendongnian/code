    class Program
    {
        static int temp = 0;
        public static int a()
        {
            temp = temp + 1;
           
            if (temp == 100)
            {
                Console.WriteLine(temp);
                return 0;
            }
            else
                Console.WriteLine(temp);
            Program.a();
            return 0;
        }
        public static void Main()
        {
            Program.a();
            Console.ReadLine();
        }
    }
