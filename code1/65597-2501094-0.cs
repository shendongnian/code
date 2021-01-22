    using System.Collections.Generic;
    
    class Program
    {
        static void Main()
        {
            var letters = new List<string>{"B","C","A"};
    
            letters.Sort(CompareStrings);
        }
    
        private static int CompareStrings(string l, string r)
        {
            if (l == "B")
                return -1;
    
            return l.CompareTo(r);
        }
    }
