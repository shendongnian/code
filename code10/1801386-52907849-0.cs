    public class Exercise1
    {
        
        
        
        public static double num1 = 3;
        public static double num2 = 2;
        
        public static string readable
        {
          get { return num1 + ", " + num2;}
        };
        public static void Main( )
        {
            System.Console.WriteLine(readable);
            
            num1 = 2;
            num2 = 3;
            
            System.Console.WriteLine(readable);
            
        }
        
    }
