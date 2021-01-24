using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
namespace ConsoleApplication1
{
    class Program
    {
        public static int sum(int num1, int num2, int num3)
        {
            int total;
            total = num1 + num2 + num3;
            return total;
        }
        public static void Main(string[] args)
        {
            Console.Write("\n\nFunction to calculate the sum of two numbers :\n");
            Console.Write("--------------------------------------------------\n");
            Console.Write("Enter a number1: ");
            int n1 = Convert.ToInt32(Console.ReadLine());
            Console.Write("Enter a number2: ");
            int n2 = Convert.ToInt32(Console.ReadLine());
            Console.Write("Enter a number3: ");
            int n3 = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("\nThe sum of three numbers is : {0} \n", sum(n1, n2, n3));
        }
    }
}
Check here : https://dotnetfiddle.net/p9E9Rw
