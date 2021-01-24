    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    namespace ConsoleApplication1
    {
        class Program
        {
            static int[] groups = { 75, 40, 0 };
            static void Main(string[] args)
            {
                int[] input = { 10, 3, 8, 23, 98, 34, 75, 23, 87, 56, 78 };
                List<List<int>> results = input.GroupBy(x => GetGroup(x)).Select(x => x.ToList()).ToList();
            }
            static int GetGroup(int number)
            {
     
                int index = -1;
                while (number < groups[++index]) ;
                return index;
            }
        }
    }
