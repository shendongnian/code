    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using Newtonsoft.Json;
    
    namespace SampleCodeCreator
    {
        class Program
        {
            static void Main(string[] args)
            {
                string jsonData;
    
                //read the json data file and store the data in a simple string
                using (StreamReader r = new StreamReader(@"[Give your File Path].json"))
                {
                    jsonData = r.ReadToEnd();                
                }
    
                PrintJsonObject("RequestBody", jsonData);                    
            }
    
            static void PrintArrayCase(string key, object obj)
            {
                Console.WriteLine("var {0}Obj = new List<string>();", key);
    
                var valueString = obj.ToString();
                var valueSplitArray = valueString.Split(',');
    
                for (int k = 0; k < valueSplitArray.Count(); k++)
                {
                    string listValue = "";
                    if (k != valueSplitArray.Count() - 1)
                    {
                        var startIndex = valueSplitArray[k].IndexOf("\"");
                        listValue = valueSplitArray[k].Substring(startIndex + 1, valueSplitArray[k].Length - startIndex - 2);
                    }
                    else
                    {
                        var startIndex = valueSplitArray[k].IndexOf("\"");
                        listValue = valueSplitArray[k].Substring(startIndex + 1, valueSplitArray[k].Length - startIndex - 5);
                    }
    
                    Console.WriteLine(@"{0}Obj.Add(""{1}"");", key, listValue);                                
                }            
            }
    
            static void PrintKeyValuePairCase(string parentObj, string key, string value)
            {
                Console.WriteLine("{0}Obj.{1} = \"{2}\";",parentObj ,key, value);
            }
    
    
            static void PrintJsonObject(string parentObject, string jsonData)
            {
                Console.WriteLine("var {0}Obj = new {0}();", parentObject);
                Console.WriteLine("\n");
    
                var jsonSubData = JsonConvert.DeserializeObject<Dictionary<string, object>>(jsonData);
    
                foreach (var data in jsonSubData)
                {
                    var dataKey = data.Key;
                    var dataValue = data.Value;
    
                    //array case
                    if (dataValue.ToString().Contains("["))
                    {
                        PrintArrayCase(dataKey, dataValue);
    
                        Console.WriteLine("\n");
                        Console.WriteLine("{0}Obj.{1} = {1}Obj;", parentObject, dataKey);
                        Console.WriteLine("\n");
                    }
                    // nested object case
                    else if (dataValue.ToString().Contains("{"))
                    {
                        PrintJsonObject(dataKey, dataValue.ToString());
    
                        Console.WriteLine("\n");
                        Console.WriteLine("{0}Obj.{1} = {1}Obj;", parentObject, dataKey);
                        Console.WriteLine("\n");
                    }
                    // simple key value pair case
                    else
                    {
                        PrintKeyValuePairCase(parentObject, dataKey, dataValue.ToString());                    
                    }
                }
            }
        }
    }
