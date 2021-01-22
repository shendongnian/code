    using System;
    using System.Collections.Generic;
    
    using MiscUtil.Collections;
    
    class Example
    {
        static void Main(string[] args)
        {
            List<string> list = new List<string>();
            list.Add("a");
            list.Add("b");
            list.Add("c");
            list.Add("d");
            list.Add("e");
            
            foreach (SmartEnumerable<string>.Entry entry in
                     new SmartEnumerable<string>(list))
            {
                Console.WriteLine ("{0,-7} {1} ({2}) {3}",
                                   entry.IsLast  ? "Last ->" : "",
                                   entry.Value,
                                   entry.Index,
                                   entry.IsFirst ? "<- First" : "");
            }
        }
    }
