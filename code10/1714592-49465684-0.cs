    using System;
    using System.Linq;
    
    public class Program
    {
        public static void Main()
        {
            int[] nums = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
            int[] reversed = nums;
            Array.Reverse(reversed); // reverse the Array
            
            foreach(int num in reversed)
            {
              Console.WriteLine(num) // print reversed array
            }
           
        }
    }
