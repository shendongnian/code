    using System;
    using System.Collections.Generic;
    using System.Linq;
    
    namespace ConsoleApp25
    {
        class Program
        {
            static void Main(string[] args)
            {
                var str1 = "AAAAAAABBBBBBB1111111";
                var result1 = Do(str1);
    
    
                var str2 = "AAAAAAABBBBBBBBBBBBBBBB111111111111111111111";
                var result2 = Do(str2);
    
    
                Console.WriteLine(string.Join(" ", result1));
                Console.WriteLine(string.Join(" ", result2));
    
                Console.ReadLine();
            }
    
            private static string[] Do(string str)
            {
                var dic = new Dictionary<char, List<char>>();
    
                foreach (var c in str)
                {
                    if (!dic.ContainsKey(c))
                    {
                        dic.Add(c, new List<char>());
                    }
    
                    dic[c].Add(c);
                }
    
                var result = new List<string>();
    
                while (dic.Any(c => c.Value.Any()))
                {
                    var tmpResult = new List<char>();
    
                    foreach (var key in dic.Keys)
                    {
                        if (dic[key].Any())
                        {
                            tmpResult.Add(key);
                            dic[key].Remove(key);
                        }
                    }
    
                    result.Add(new string(tmpResult.ToArray()));
                }
    
                return result.ToArray();
            }
        }
    }
