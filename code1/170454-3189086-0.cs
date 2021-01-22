    using System;
    using System.Collections.Generic;
    
    class Test
    {
        static void ShowCurrentAndNext(IEnumerator<int> iterator)        
        {
            Console.WriteLine("ShowCurrentAndNext");
            Console.WriteLine(iterator.Current);
            iterator.MoveNext(); // Let's assume it returns true
            Console.WriteLine(iterator.Current);
        }
        
        static void Main()
        {
            List<int> list = new List<int> { 1, 2, 3, 4, 5 };
            using (var iterator = list.GetEnumerator())
            {
                iterator.MoveNext(); // Get things going
                ShowCurrentAndNext(iterator);
                ShowCurrentAndNext(iterator);
                ShowCurrentAndNext(iterator);
            }
        }
    }
