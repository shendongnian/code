    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    
    namespace ConsoleApplication1
    {
        class Program
        {
            delegate string CreateGroupingDelegate(int i);
    
            static void Main(string[] args)
            {
                List<int> list = new List<int>() { 1, 2, 3, 4, 5, 7, 8, 9, 10, 11, 12, 13, 69, 2007};
                int running_total = 0;
    
                var result_set =
                    from x in list
                    select new
                    {
                        num = x,
                        running_total = (running_total = running_total + x)
                    };
    
                foreach (var v in result_set)
                {
                    Console.WriteLine( "list element: {0}, total so far: {1}",
                        v.num,
                        v.running_total);
                }
                
                Console.ReadLine();
            }
        }
    }
