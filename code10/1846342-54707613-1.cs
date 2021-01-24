    using System;
    using System.Collections.Generic;
    
    namespace ConsoleApp27
    {
        internal class Program
        {
            private static void Main(string[] args)
            {
                var resultObject = new ResultObject();
                var changesDictionary = new Dictionary<string, string>();
    
                changesDictionary.Add(nameof(ResultObject.field1), "q1");
                changesDictionary.Add(nameof(ResultObject.field2), "q2");
                changesDictionary.Add(nameof(ResultObject.field3), "q3");
                changesDictionary.Add(nameof(ResultObject.field4), "q4");
    
                changesDictionary.TryGetValue(nameof(ResultObject.field1), out resultObject.field1);
                changesDictionary.TryGetValue(nameof(ResultObject.field2), out resultObject.field2);
                changesDictionary.TryGetValue(nameof(ResultObject.field3), out resultObject.field3);
                changesDictionary.TryGetValue(nameof(ResultObject.field4), out resultObject.field4);
    
                Console.WriteLine(resultObject.field1);
                Console.WriteLine(resultObject.field2);
                Console.WriteLine(resultObject.field3);
                Console.WriteLine(resultObject.field4);
                Console.ReadLine();
            }
    
            public class ResultObject
            {
                public string field1;
                public string field2;
                public string field3;
                public string field4;
            }
        }
    }
