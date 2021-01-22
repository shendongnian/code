    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    
    
    namespace ConsoleApplication1
    {
        class Program
        {
            static void Main(string[] args)
            {
                String[] val = { "helloword1", "orange", "grape", "pear" };
                String sep = "";
                string stringToCheck = "word1";
    
                bool match = String.Join(sep,val).Contains(stringToCheck);
    
                bool anothermatch = val.Any(s => s.Contains(stringToCheck));
    
            }
        }
    }
