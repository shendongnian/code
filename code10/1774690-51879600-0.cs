    using System;
    using System.Collections.Generic;
    using System.Linq;
    
    namespace MyNamespace
    {
        public class Program
        {
            public static void Main()
            {
                List<List<float>> arrayFloatValue = new List<List<float>>
                {
                    new List<float> {1, 2, 3},
                    new List<float> {1, 3, 2},
                    new List<float> {1, 2, 3},
                    new List<float> {3, 5, 7}
                };
    
                var hsArrayFloatValue = new HashSet<List<float>>(arrayFloatValue, new ListComparer());
                List<List<float>> filteredArrayFloatValue = hsArrayFloatValue.ToList();
                
                DisplayNestedList(filteredArrayFloatValue);
    
                //output:
                //1 2 3
                //1 3 2
                //3 5 7
            }
    
            public static void DisplayNestedList(List<List<float>> nestedList)
            {
                foreach (List<float> list in nestedList)
                {
                    foreach (float f in list)
                        Console.Write(f + " ");
    
                    Console.WriteLine();
                }
    
                Console.ReadLine();
            }
        }
    
        public class ListComparer : IEqualityComparer<List<float>>
        {
            public bool Equals(List<float> x, List<float> y)
            {
                if (x == null && y == null)
                    return true;
    
                if (x == null || y == null || x.Count != y.Count)
                    return false;
    
                return !x.Where((t, i) => t != y[i]).Any();
            }
    
            public int GetHashCode(List<float> obj)
            {
                int result = 0;
    
                foreach (float f in obj)
                    result |= f.GetHashCode();
    
                return result;
            }
        }
    }
