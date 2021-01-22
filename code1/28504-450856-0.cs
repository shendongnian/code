    using System;
    using System.Collections.Generic;
    
    static class Test
    {
        static int GetSortedIndex<T>(this List<T> list, T entry)
        {
            int index = list.BinarySearch(entry);
            return index >= 0 ? index : ~index;
        }
        
        static void Main()
        {
            List<char> container = new List<char> { 'b', 'd', 'g' };
            Console.WriteLine(container.GetSortedIndex('a'));
            Console.WriteLine(container.GetSortedIndex('b'));
            Console.WriteLine(container.GetSortedIndex('c'));
            Console.WriteLine(container.GetSortedIndex('d'));
            Console.WriteLine(container.GetSortedIndex('e'));
            Console.WriteLine(container.GetSortedIndex('f'));
            Console.WriteLine(container.GetSortedIndex('g'));
            Console.WriteLine(container.GetSortedIndex('h'));
        }
    }
