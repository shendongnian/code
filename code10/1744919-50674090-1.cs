    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text.RegularExpressions;
    
    namespace Rextester
    {
        public class Program
        {
            public static void Main(string[] args)
            {
                
                Dictionary<int, string> dict = new Dictionary<int, string>();
    
                dict.Add(1, "Jack");
                dict.Add(2, "Peter");
                dict.Add(3, "Chris");
                dict.Add(4, "Peter");
    
                var key = dict.FirstOrDefault(v => v.Value == "Peter").Key;
                
                Console.WriteLine(key);
            }
        }
    }
