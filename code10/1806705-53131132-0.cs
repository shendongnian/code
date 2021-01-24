    public class Test 
    {
        public static int run = 0;
    
        public static void Main(string[] args)
        {
            
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
