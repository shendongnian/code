    public class Program 
    {
        private static field run;
        public static void Main(string[] args)
        {
            run = 0;
            Menu();
        }
        static void Menu()
        {
            run++;
    
            if (run <= 1) {
                Welcome();
            }
        }
    }
