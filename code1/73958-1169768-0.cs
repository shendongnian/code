    using System;
    using System.Linq;
    
    public class Test
    {
        static void Main()        
        {
            int[] array = new int[7] { 1, 3, 5, 2, 8, 6, 4 };
            var topThree = (from i in array 
                            orderby i descending 
                            select i).Take(3);
            
            foreach (var x in topThree)
            {
                Console.WriteLine(x);
            }
        }
    }
