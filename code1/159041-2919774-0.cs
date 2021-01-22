    using System;
    using System.Collections.Generic;
    
    class Program
    {
        static void Main()
        {
            int a[]=new int[]{4,6,8,9,11,12};
            int b[]=new int[]{3,5,7,13,14};
            int c[]=new int[]{1,2,15,16,17};
    
    
            foreach (int element in a)
            {
                Console.WriteLine(element);
            }
            foreach (int element in b)
            {
                Console.WriteLine(element);
            }
            foreach (int element in c)
            {
                Console.WriteLine(element);
            }
    
            var list = new List<int>();
            list.AddRange(a);
            list.AddRange(b);
            list.AddRange(c);
    
            int[] d = list.ToArray();
    
            foreach (int element in d)
            {
                Console.WriteLine(element);
            }
        }
