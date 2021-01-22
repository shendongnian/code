    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text.RegularExpressions;
    
    namespace SO
    {
        class Program
        {
            static void Main(string[] args)
            {
                string input = @"accountid=123456 type=prem servertime=1260968445";
    
                string pattern = @"(?<Key>[^ =]+)(?:\=)(?<Value>[^ ]+)(?=\ ?)";
    
                Dictionary<string, string> fields = 
                    (from Match m in Regex.Matches(input, pattern)
                       select new
                       {
                           key = m.Groups["Key"].Value,
                           value = m.Groups["Value"].Value
                       }
                    ).ToDictionary(p => p.key, p => p.value);
    
                //iterate over all fields
                foreach (KeyValuePair<string, string> field in fields)
                {
                    Console.WriteLine(
                        string.Format("{0} : {1}", field.Key, field.Value)
                    );
                }
    
                //get value from a key
                Console.WriteLine(
                    string.Format("{0} : {1}", "type", fields["type"])
                );
            }
        }
    }
