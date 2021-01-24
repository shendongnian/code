    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.IO;
    namespace ConsoleApplication47
    {
        class Program
        {
            const string INPUT_FILENAME = @"c:\temp\test.txt";
            const string OUTPUT_FILENAME = @"c:\temp\test1.txt";
            static void Main(string[] args)
            {
                Dictionary<string, List<string>> dict = new Dictionary<string, List<string>>();
                using (StreamReader reader = new StreamReader(INPUT_FILENAME))
                {
                    string input = "";
                    string strKey = "";
                    while ((input = reader.ReadLine()) != null)
                    {
                        string[] inputArray = input.Split(new char[] { ',' });
                        if (inputArray[0].Contains("*"))
                        {
                            int key = int.Parse(inputArray[0].Replace("*", ""));
                            strKey = "**" + key + "**";
                        }
                        else
                        {
                            strKey = int.Parse(inputArray[0]).ToString();
                        }
                        if (dict.ContainsKey(strKey))
                        {
                            dict[strKey].Add(inputArray[1]);
                        }
                        else
                        {
                            dict.Add(strKey, new List<string>() { inputArray[1] });
                        }
                    }
                }
                using (StreamWriter writer = new StreamWriter(OUTPUT_FILENAME))
                {
                    foreach(KeyValuePair<string,List<string>> row in dict)
                    {
                       writer.WriteLine("HI:{0},{1}", row.Key, string.Join(",", row.Value));
                    }
                }
     
            }
        }
    }
