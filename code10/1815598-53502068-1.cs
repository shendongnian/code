    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.IO;
    namespace ConsoleApplication86
    {
        class Program
        {
            const string FILENAME = @"c:\temp\test.txt";
            static void Main(string[] args)
            {
                Boolean foundFeature = false;
                
                List<List<string>> data = new List<List<string>>();
                StreamReader reader = new StreamReader(FILENAME);
                string line = "";
                List<string> newFeature = null;
                while ((line = reader.ReadLine()) != null)
                {
                    line = line.Trim();
                    if (line.Length > 0)
                    {
                        //ignore everything before 1st feature
                        if (foundFeature == false)
                        {
                            if (line.StartsWith("Feature"))
                            {
                                foundFeature = true;
                                newFeature = new List<string>();
                                data.Add(newFeature);
                            }
                        }
                        else
                        {
                            if (line.StartsWith("Feature"))
                            {
                                foundFeature = true;
                                newFeature = new List<string>();
                                data.Add(newFeature);
                            }
                            else
                            {
                                if(line.StartsWith("\""))
                                {
                                    foundFeature = false;
                                }
                                else
                                {
                                    newFeature.Add(line);
                                }
                            }
                        }
                    }
                }
                reader.Close();
                 
             }
     
        }
     
    }
