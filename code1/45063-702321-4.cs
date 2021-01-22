    using System;
    using System.Collections.Generic;
    using ExtensionFSharp;
        class Program
        {
            static void Main(string[] args)
            {
                var method = typeof (CollectionExtensions).GetMethod("Enumerable.RangeChar.2.static");
    
    
                var rangeChar = (IEnumerable<char>) method.Invoke(null, new object[] {'a', 'z'});
                foreach (var c in rangeChar)
                {
                    Console.WriteLine(c);
                }
            }
        }
