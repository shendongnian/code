    using System;
    
    public class Exercise1
    {
    
        public static double num = 3;
      
        public static string readable;
    
        public static string Num1
        {
            get
            {
                 readable = readable + "," +num;
                 return readable.TrimStart(',');
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
