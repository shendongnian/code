    using System;
    using System.Collections.Generic;
    using System.Linq;
    
    public class Test
    {
        private IEnumerable<string> Tables
        {
            get {
                 yield return "Foo";
                 yield return "Bar";
             }
        }
        
        static void Main()
        {
            var x = new Test();
            Console.WriteLine(x.Tables.Count());
        }
    }
