    using System;
    using System.Collections.Generic;
    
    class Test
    {
        static void Main()
        {
            List<int> originalList = new List<int> { 5, 6, 7 };
            List<int> cloneList = new List<int>(originalList);
            
            cloneList.Add(8);
            cloneList[0] = 2;
            Console.WriteLine(originalList.Count); // Still 3
            Console.WriteLine(originalList[0]); // Still 5
        }
    }
