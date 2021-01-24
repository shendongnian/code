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
                
                string result1 = getName(new {Name = "jack", Age = 12});    // result1 = "jack"
                string result2 = getName(new {Age = 12});
                
                Console.WriteLine(result1);
                Console.WriteLine(result2);
            }
            
            public static string getName(object obj)
            {
                var testData = obj.GetType().GetProperties().ToDictionary(p => p.Name, p => p.GetValue(obj).ToString());
                if(testData.Any(d => d.Key == "Name")){
                    return testData["Name"];
                }
                return null;
            }
        }
    }
