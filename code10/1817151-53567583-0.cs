    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    
    namespace classObjectMethodBasic
    {
        public class Program
        {
            static void Main()
            {
                Console.WriteLine("Input a number for first number to do a math on: ");
                string input1 = Console.ReadLine();
    			int number1 = 0;
    			int.TryParse(input1, out number1);
    
                Console.WriteLine("Input a number for second number to do a math on or you need not enter one: ");
                string input2 = Console.ReadLine();
    			int number2 = 0;
    			int.TryParse(input2, out number2);
    
                int result1 = new int();
                result1 = Math.math(number1, number2);
    
                Console.WriteLine("Math result: " + result1);
                Console.ReadLine();
            }
        }
        public class Math
        {
            public static int math(int number1, int number2 = 3)
            {
                int result1 = number1 + number2;
                return result1;
            }
        }
    }
