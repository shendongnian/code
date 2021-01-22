using System;
using System.Collections.Generic;
using System.Text;
namespace FillRandom
{
    class Program
    {
        static void Main(string[] args)
        {
            int minValue = 1;
            int maxValue = 100;
            //create a list of int with capacity set as 100
            List<int> array = new List<int>(100);
            FillArray(array, minValue, maxValue, array.Capacity);
            //print out all values in the array
            foreach (int i in array)
            {
                Console.WriteLine(i);
            }
        }
        private static void FillArray(List<int> array, int minValue, int maxValue, int capacity)
        {
            int count = 0;
            while (array.Count != capacity - 1)
            {
                Random rnd = new Random();
                int value = rnd.Next(minValue, maxValue);
                if (!array.Contains(value))
                {
                    array.Add(value);
                }
                count++;
            }
            //print out the number of times the looping occurs
            Console.WriteLine("count: "+count);
        }        
    }
}
