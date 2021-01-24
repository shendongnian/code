    using System;
    using System.Collections.Generic;
    
    namespace ConsoleApp1
    {
    class Program
        {
    
            static void Main(string[] args)
            {
                List<List<int>> mainList = new List<List<int>>();
    
                List<int> newList = new List<int>();
    
    
                Random rand = new Random();
                for (int i = 0; i < 30; i++)
                {
                    int ra = rand.Next(200);
       
                    if (i % 5  == 0)
                    {
                        if (newList.Count > 0)
                        {
                            newList = new List<int>();
                            mainList.Add(newList);
                        }
                    }
                    newList.Add(ra);
    
                }
     
                mainList.Sort( new MaxComparer(mainList, false));
                
                foreach (List<int> oneL in mainList)
                {
                    foreach (int oneInt in oneL)
                    {
                        Console.Write(oneInt + " ");
                    }
                    Console.WriteLine();
                }
    
            }
    
            public class MaxComparer : IComparer<List<int>>
            {
                bool order = false;
                Dictionary<int, int> helper = new Dictionary<int, int>();
                public MaxComparer(List<List<int>> sortList, bool Order)
                {
                    order = Order;
    
                    foreach (List<int> oneL in sortList)
                    {
                        int max = int.MinValue;
                        foreach (int oneInt in oneL)
                        {
                            if (max < oneInt) max = oneInt;
                        }
                        helper.Add(oneL.GetHashCode(), max);
                    }
                }
    
                public int Compare(List<int> x, List<int> y)
                {
                    return helper[x.GetHashCode()].CompareTo(helper[y.GetHashCode()]) * (order ? 1:-1);
    
                }
            }
      }
}
