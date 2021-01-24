    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    namespace PrintOutput
    {
        class Program
        {
            static void Main(string[] args)
            {
                List<int> nums = new List<int>(new int[] { 1, 2, 3, 4, 5 });
                while(nums.Count()>0)
                {
                    Console.WriteLine(string.Join(" ", nums));
                    nums.Remove(nums.Max());
                }
                Console.ReadLine();
            }
        }
    }
