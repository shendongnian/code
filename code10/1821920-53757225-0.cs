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
                Dictionary<long, List<Tuple<object, Object>>> testDict = new Dictionary<long, List<Tuple<object, Object>>>();
                testDict.Add(12345 , new List<Tuple<object, object>>(){ 
                    new Tuple<object, object>("developer1", "studio1"), 
                    new Tuple<object, object>("developer1", "studio2"), 
                    new Tuple<object, object>("developer1", "studio3") 
                });
                
                foreach (KeyValuePair<long, List<Tuple<object, Object>>> kvp in testDict)
                {
                    Console.WriteLine("Key = {0}, Value = {1}", kvp.Key, kvp.Value);
                    foreach(Tuple<object, Object> tuple in kvp.Value)
                    {
                        Console.WriteLine("Item1 = {0}, Item2 = {1}", tuple.Item1, tuple.Item2);
                    }
                }
            }
        }
    }
