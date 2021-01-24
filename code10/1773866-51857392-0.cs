    using System;
    using System.Collections.Generic;
    
    namespace ConsoleApp1
    {
        class Program
        {
    
            static void Main(string[] args)
            {
                List<List<int[]>> mainList = new List<List<int[]>>();
    
    
    
                Random rand = new Random();
                for (int i = 0; i < 30; i++)
                {
                    List<int[]> subList = new List<int[]>();
    
                    int limj = rand.Next(5);
                    for (int j = 0; j < 5 + limj; j++)
                    {
                        int limk = rand.Next(5);
                        int[] arrayInt = new int[limk + 5];
                        for (int k = 0; k < limk + 5; k++)
                        {
                            arrayInt[k] = rand.Next(200);
                        }
                        subList.Add(arrayInt);
    
                    }
                    mainList.Add(subList);
    
                }
    
                mainList.Sort(new MaxComparer(mainList, false));
    
                foreach (List<int[]> oneL in mainList)
                {
                    foreach (int[] arrayList in oneL)
                    {
                        foreach (int i in arrayList) Console.Write(i + " ");
                        Console.Write("|");
                    }
                    Console.WriteLine();
                }
    
            }
    
            public class MaxComparer : IComparer<List<int[]>>
            {
                bool order = false;
                public MaxComparer(List<List<int[]>> sortList, bool Order)
                {
                    order = Order;
    
    
                }
    
                public int Compare(List<int[]> x, List<int[]> y)
                {
    
                    return x[0][0].CompareTo(y[0][0]) * (order ? 1 : -1);
    
                }
            }
        }
    }
