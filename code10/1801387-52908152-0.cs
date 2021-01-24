    using System;
    
    public class Exercise1
    {
    
        public static double num = 3;
      
        public static string readable;
    
        public static string Num1
        {
            get
            {
                 readable = num + "," + readable;
                return readable.TrimEnd(',');
            }
        }
    
        public static void Main()
        {
            Console.WriteLine(Num1);
            num = 4;
            Console.WriteLine(Num1);
            num = 5;
            Console.WriteLine(Num1);
            Console.ReadKey();
        }
    
    }
