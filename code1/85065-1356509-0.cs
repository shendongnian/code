    class Test
    {
        public delegate bool Sample(DateTime dt);
        static void Main()
        {
            Sample j = A;
            j += B;
            j(DateTime.Now);
    
        }
        static bool A(DateTime d)
        {
            Console.WriteLine(d);
            return true;
        }
        static bool B(DateTime d)
        {
            Console.WriteLine(d);
            return true;
        }
    }
