    using System;
    using System.Collections.Generic;
    
    namespace DynamicDictionary
    {
        class Test
        {
            static void Main(string[] args)
            {
                var factory = new DictionaryRuntime.DynamicDictionaryFactory();
                var dict = factory.CreateDynamicGenericInstance(typeof(String), typeof(int));
    
                var typedDict = dict as Dictionary<String, int>;
    
                if (typedDict != null)
                {
                    Console.WriteLine("Dictionary<String, int>");
    
                    typedDict.Add("One", 1);
                    typedDict.Add("Two", 2);
                    typedDict.Add("Three", 3);
    
                    foreach(var kvp in typedDict)
                    {
                        Console.WriteLine("\"" + kvp.Key + "\": " + kvp.Value);
                    }
                }
                else
                    Console.WriteLine("null");
            }
        }
    }
