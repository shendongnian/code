    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using Newtonsoft.Json;
    
    namespace SampleCodeCreator
    {
        class Program
        {
            // Declaring the variables
            static string jsonFilePath = @"[Your File Path]";
            static string outputFilePath = @"[Your File Path]";
            static string  jsonData;
            static Dictionary<string, string> classMap = new Dictionary<string, string>(StringComparer.InvariantCultureIgnoreCase);        
    
            static void Main(string[] args)
            {            
                // Initializing Class map which is used to map the json object to Project Model Class
                InitializeClassMap();
    
                // clear current data in the output file
                using (System.IO.StreamWriter file = new System.IO.StreamWriter(outputFilePath, false))
                {
                    file.Write(String.Empty);
                }
                
                // read the json data file and store the data in a simple string
                using (StreamReader r = new StreamReader(jsonFilePath))
                {
                    jsonData = r.ReadToEnd();                
                }
    
                // Call the method for the whole json data
                PrintJsonObject("RequestBody", jsonData);            
            }        
    
            static void PrintJsonObject(string parentObject, string jsonData)
            {
                // if the parent object has any mapped class, then set the object name
                parentObject = MappedClass(parentObject);
    
                Console.WriteLine("var {0}Obj = new {1}();", ToCamelCase(parentObject), parentObject);
                SetOutput("var " + ToCamelCase(parentObject) + "Obj = new " + parentObject + "();");
                Console.WriteLine("");
                SetOutput("");
    
    
                // Deserialize the Json data and iterate through each of its sub-sections
                var jsonSubData = JsonConvert.DeserializeObject<Dictionary<string, object>>(jsonData);
                foreach (var data in jsonSubData)
                {
                    var dataKey = data.Key;
                    var dataValue = data.Value;
    
                    // array case (if the sub element is an array)
                    if (dataValue.ToString().Contains("["))
                    {
                        PrintArrayCase(dataKey, dataValue);
    
                        Console.WriteLine("{0}Obj.{1} = {1}Obj;", ToCamelCase(parentObject), dataKey);
                        SetOutput(ToCamelCase(parentObject) + "Obj." + dataKey + " = " + dataKey + "Obj;");
    
                        Console.WriteLine("");
                        SetOutput("");
    
                    }
                    // nested object case (if the sub element itself contains another json format body)
                    else if (dataValue.ToString().Contains("{"))
                    {
                        // Recursive Call
                        PrintJsonObject(dataKey, dataValue.ToString());
    
                        Console.WriteLine("{0}Obj.{1} = {1}Obj;", ToCamelCase(parentObject), dataKey);
                        SetOutput(ToCamelCase(parentObject) + "Obj." + dataKey + " = " + dataKey + "Obj;");
    
                        Console.WriteLine("");
                        SetOutput("");
                    }
                    // simple key value pair case
                    else
                    {
                        PrintKeyValuePairCase(parentObject, dataKey, dataValue.ToString());                    
                    }
                }            
            }
    
            static void PrintArrayCase(string key, object obj)
            {
                Console.WriteLine("var {0}Obj = new List<string>();", key);
                SetOutput("var " + key + "Obj = new List<string>();");
                
                // The array value is split into its values
                // e.g. [abc, def, ghi]  -> [abc] [def] [ghi]
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
    
                    // each value is then added to the main list object
                    Console.WriteLine(@"{0}Obj.Add(""{1}"");", ToCamelCase(key), listValue);
                    SetOutput(@""+ToCamelCase(key)+@"Obj.Add("""+listValue+@""");");
                }
    
                Console.WriteLine("");
                SetOutput("");
            }
    
            static void PrintKeyValuePairCase(string parentObj, string key, string value)
            {
                Console.WriteLine("{0}Obj.{1} = \"{2}\";", ToCamelCase(parentObj), key, value);
                SetOutput("" + ToCamelCase(parentObj) + "Obj." + key + " = \"" + value + "\";");
            }
    
            static string ToCamelCase(string str)
            {
                if (!String.IsNullOrEmpty(str))
                {
                    return str.Substring(0, 1).ToLower() + str.Substring(1, str.Length - 1);
                }
                else
                {
                    return null;
                }
            }
    
            static string MappedClass(string str)
            {
                if (classMap.ContainsKey(str))
                    return classMap[str];
                else
                    return str;
            }
    
            static void InitializeClassMap()
            {
                classMap.Add("employeeInformation", "EmployeeInfo");            
            }
    
            static void SetOutput(string str)
            {
                using (System.IO.StreamWriter file = new System.IO.StreamWriter(outputFilePath, true))
                {
                    file.WriteLine(str);
                }
            }
        }
    }
