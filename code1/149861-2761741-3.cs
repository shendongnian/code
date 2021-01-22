    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Diagnostics;
    
    namespace SubsetSum
    {
        class Program
        {
            static void Main(string[] args)
            {
                var ns = new List<int>();
                for (int i = 0; i < 1000; i++) ns.Add(1);
                var s1 = Stopwatch.StartNew();
                bool result = SubsetSum(ns, 1000);
                s1.Stop();
                Console.WriteLine(result);
                Console.WriteLine(s1.Elapsed);
                Console.Read();
            }
    
            static bool SubsetSum(ist<int> nums, int targetL)
            {
                var left = new List<int> { 0 };
                var right = new List<int> { 0 };
                foreach (var n in nums)
                {
                    if (left.Count < right.Count) left = Insert(n, left);
                    else right = Insert(n, right);
                }
                int lefti = 0, righti = right.Count - 1;
                while (lefti < left.Count && righti >= 0)
                {
                    int s = left[lefti] + right[righti];
                    if (s < target) lefti++;
                    else if (s > target) righti--;
                    else return true;
                }
                return false;
            }
    
            static List<int> Insert(int num, List<int> nums)
            {
                var result = new List<int>();
                int lefti = 0, left = nums[0]+num;
                for (var righti = 0; righti < nums.Count; righti++)
                {
    
                    int right = nums[righti];
                    while (left < right)
                    {
                        result.Add(left);
                        left = nums[++lefti] + num;
                    }
                    if (right != left) result.Add(right);
                }
                while (lefti < nums.Count) result.Add(nums[lefti++] + num);
                return result;
            }
        }
    }
