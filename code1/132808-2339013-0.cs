    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    
    namespace ConsoleApplication2
    {
        class Program
        {
            static void Main(string[] args)
            {
                var list = new[] {-7, 1, 5, 2, -4, 3, 0};
                Console.WriteLine(equi(list));
                Console.ReadLine();
            }
    
            static int equi(int[] A)
            {
                if (A == null || A.Length == 0)
                    return -1;
    
                if (A.Length == 1)
                    return 0;
    
                var upperBoundSum = GetTotal(A);
                var lowerBoundSum = 0;
                for (var i = 0; i < A.Length; i++)
                {
                    lowerBoundSum += (i - 1) >= 0 ? A[i - 1] : 0;
                    upperBoundSum -= A[i];
                    if (lowerBoundSum == upperBoundSum)
                        return i;
                }
                return -1;
            }
    
            private static int GetTotal(int[] ints)
            {
                var sum = 0;
                for(var i=0; i < ints.Length; i++)
                    sum += ints[i];
                return sum;
            }
        }
    }
