    public class First_class
    {
        protected static int variable_1 = 1;
        protected static int variable_2 = 1;
        protected static int variable_3 = 3;
        protected static string variable_4 = "test1";
    }
        
    class Program: First_class
    {
        static void Main(string[] args)
        {
            Console.WriteLine(variable_1);
            Console.WriteLine(variable_2);
            Console.WriteLine(variable_3);
            Console.WriteLine(variable_4);
        }
     }
