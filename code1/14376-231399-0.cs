    using System;
    using System.Collections;
    
    namespace ConsoleApplication3
    {
        class Program
        {
            static void Main(string[] args)
            {
                ArrayList numbers = new ArrayList();
                foreach (int number in new int[] { 10, 9, 8, 7, 6, 5, 4, 3, 2, 1 })
                {
                    numbers.Add(number);
                }
                numbers.Insert(numbers.Count - 1, 75);
                numbers.Remove(7);
                numbers.RemoveAt(6);
                for (int i = 0; i < numbers.Count; i++)
                {
                    int number = (int)numbers[i];
                    Console.WriteLine(number);
                }
            }
        }
    }
