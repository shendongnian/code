    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    
    namespace ConsoleApp5
    {
        class EvenComparer : EqualityComparer<int>
        {
           
    
            public override bool Equals(int x, int y)
            {
                if((x % 2 == 0 && y % 2 == 0))
                {
                    return true;
                }
    
                return false;
    
            }
    
            public override int GetHashCode(int obj)
            {
                return obj.GetHashCode();
            }
        }
    
    
        class Program
        {
            static void Main(string[] args)
            {
    
                //If you want to check whether the arrays are equal in the sense of containing the same elements in the same order
    
                int[] Array1 =  { 2, 4, 6};
                int[] Array2 =  {8, 10, 12 };
    
                
    
                string[] arr1 = { "Jar Jar Binks", "Kill! Kill!", "Aaaaargh!" };
                string[] arr2 = { "Jar Jar Binks", "Kill! Kill!", "Aaaaargh!" };
    
                bool areEqual = (arr1 as IStructuralEquatable).Equals(arr2, StringComparer.Ordinal);
                bool areEqual2 = (Array1 as IStructuralEquatable).Equals(Array2, new EvenComparer());
    
                Console.WriteLine(areEqual);
                Console.WriteLine(areEqual2);
    
             
                Console.WriteLine(Array1.GetHashCode());
                Console.WriteLine(Array2.GetHashCode());
            
            }
        }
    }
