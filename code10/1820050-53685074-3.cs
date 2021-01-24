    using System;
    using System.Linq;
    
    public class Program
    {
        public static void Main()
        {
            int j = -123;        
            int k = 123;        
            double l = -123.456;
            double m = 123.456;
    
            Console.WriteLine(j.Reverse());
            Console.WriteLine(k.Reverse());
            Console.WriteLine(l.Reverse());
            Console.WriteLine(m.Reverse());
            Console.ReadKey();
        }
    }
    
    public static class Extensions
    {
        public static int Reverse(this int value)
        {
            return Math.Sign(value) * int.Parse(new string(Math.Abs(value).ToString().Reverse().ToArray()));
        }
    
        public static double Reverse(this double value)
        {
            return Math.Sign(value) * double.Parse(new string(Math.Abs(value).ToString().Reverse().ToArray()));
        }
    }
    //OUTPUTS
    //-321
    //321
    //-654.321
    //654.321
