using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace ConsoleMinMax
{
    class Program
    {
        static void Main(string[] args)
        {
            sbyte[] array1 = { 1, -1, -2, 0, 99, -111 };
            MinMax(array1);
            void MinMax(sbyte[] array)
            {
                // Report minimum and maximum values.
                Console.WriteLine("max = {0}; min = {1}", array.Max(), array.Min());
            }
        }
    }
}
