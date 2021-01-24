    using System;
    using System.Linq;
    
    public class Program
    {
        public static void Main()
        {
            int[] nums = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
            Array.Reverse(nums); // reverse the Array
            
            foreach(int num in nums)
            {
              Console.WriteLine(num) // print reversed array
            }
           
        }
    }
