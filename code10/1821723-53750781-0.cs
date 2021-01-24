    class First_class
    {
        public static int variable_1 = 1; // This can be accessed from outside
        public int variable_2 = 1; // This can be accessed from outside too
        int variable_3 = 3; // This can not be accessed from outside
        string variable_4 = "test1"; // This also can not be accessed from outside
    }
    class Program
    {
        static void Main(string[] args)
        {
            var o = new First_class();
            Console.Writeline(First_class.variable_1);
            Console.Writeline(o.variable_2);
            Console.Writeline(o.variable_3); // Error: variable_3 is private
        }
    }
