    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    
    namespace Task_8_Set_III
    {
        class Program                       
         {
            static void Main(string[] args)
            {
                double sum = 0;
                for (int i = 1; i <= 7; i++)
                {
                    double c = i / fact(i);
                    sum += c;
                    Console.WriteLine("Factorial is : " + c);
                    Console.ReadLine();
                    Console.WriteLine("By Adding.. will give " + sum);
    
                }
            }
            static double fact(double value)
            {
                if (value ==1)
                {
                    return 1;
                }
                else
                {
                    return (value * (fact(value - 1)));
                }
            }
        }
    }
