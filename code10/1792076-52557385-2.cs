    class C
    {
        public static bool operator true(C c)
        {
            System.Console.WriteLine("C operator true");
            return true;
        }
    
        public static bool operator false(C c)
        {
            System.Console.WriteLine("C operator false");
            return true; // Oops
        }
    
        public static C operator &(C a, C b)
        {
            System.Console.WriteLine("C operator &");
            return a;
        }
    }
