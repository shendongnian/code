    using System;
    using System.Linq;
    using System.Collections.Generic;
    public static class ToListTest
    {
        public static int Main(string[] args)
        {
            List<int> intlist = new List<int>();
            for (int i = 0; i < 1000000; i++)
                intlist.Add(i);
            IEnumerable<int> intenum = intlist;
            for (int i = 0; i < 1000; i++)
            {
                List<int> foo = intenum.ToList();
            }
            return 0;
        }
    }
