    using System;
    using System.Collections.Generic;
    
    namespace ConsoleApp
    {
        public class Program
        {
            static void Main(string[] args)
            {
                List<Tuple<double, int, int>> FHM = new List<Tuple<double, int, int>>();
                FHM.Add(Tuple.Create(2500.00, 1, 5));
                FHM.Add(Tuple.Create(2400.00, 2, 300));
                FHM.Add(Tuple.Create(2300.00, 4, 10));
                FHM.Add(Tuple.Create(2600.00, 1, 325));
    
                var sorted = new SortedList<double, Tuple<double, int, int>>();
                foreach (Tuple<double, int, int> t in FHM)
                {
                    sorted.Add(t.Item1, t);
                }
            }
        }
    }
