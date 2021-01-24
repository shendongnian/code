    class Second_class
    {
        int variable_5 = 5;
        int variable_6 = 6;
        int variable_7 = 7;
        public string varaible_8 = "test_2"; //only this field can be accessed
    }
    
    public class First_class
    {
        public int variable_1 = 1;
        public int variable_2 = 1;
        protected int variable_3 = 3; // can be accessed via inheritance
        private string variable_4 = "test1"; // cannot be accessed due to privacy level
    }
    
    class Program
    {
        static void Main(string[] args)
        {
            var obj1 = new First_class();
            Console.WriteLine(obj1.variable_1);
            Console.WriteLine(obj1.variable_2);
    
            var obj2 = new Second_class();
            Console.WriteLine(obj2.varaible_8);
    
        }
    }
