    using System;
    using System.Linq;
    
    public class Program
    {
    
        public static void Main()
        {
            int j = -123;
    
            int a = j.ToString().Reverse().Aggregate(0, (y, x) => 10 * y + x - '0');
            int b = -(123.ToString().Reverse().Aggregate(0, (y, x) => 10 * y + x - '0'));
            int c = -123.ToString().Reverse().Aggregate(0, (y, x) => 10 * y + x - '0');
            int d = -(123).ToString().Reverse().Aggregate(0, (y, x) => 10 * y + x - '0');
            
            //Make -123 like line below.
            int e = (-123).ToString().Reverse().Aggregate(0, (y, x) => 10 * y + x - '0');
    
            Console.WriteLine($"{a} , {b} , {c} , {d}, {e}");
            Console.ReadKey();
        }
    }
    //OUTPUTS
    //3207 , -321 , -321 , -321, 3207
