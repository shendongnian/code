    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.IO;
    using System.Data;
    using System.Text.RegularExpressions;
    namespace ConsoleApplication1
    {
        class Program
        {
            const string FILENAME = @"c:\temp\test.txt";
            static void Main(string[] args)
            {
                new SQLData(FILENAME);
            }
        }
        public class SQLData
        {
            public static DataTable dt = null;
            public SQLData() { }
            public SQLData(string filename)
            {
                dt = new DataTable();
                dt.Columns.Add("Name", typeof(string));
                dt.Columns.Add("Type", typeof(string));
                dt.Columns.Add("Text", typeof(string));
                dt.Columns.Add("Numeric", typeof(decimal));
                dt.Columns.Add("L_Value", typeof(string));
                string patternNumber = @"\d+(.\d+)?";
                //use string read instead of StreamReader if data is going from a web response
                StreamReader reader = new StreamReader(filename);
                string inputLine = "";
                DataRow row = null;
                string type = "";
                while ((inputLine = reader.ReadLine()) != null)
                {
                    inputLine = inputLine.Trim();
                    if (inputLine.Length > 0)
                    {
                        if(!inputLine.StartsWith("\""))
                        {
                            string name = inputLine.Substring(0, 12).Trim();
                            type = inputLine.Substring(12, 9).Trim();
                            string value = inputLine.Substring(21).Trim();
                            row = dt.Rows.Add();
                            row["Name"] = name;
                            row["Type"] = type;
                            switch (type)
                            {
                                case "Pub   C" :
                                    row["Text"] = value.Replace("\"", "").Trim();
                                    break;
                                case "Pub   N":
                                    string strNumber = Regex.Match(value, patternNumber).Value;
                                    row["Numeric"] = decimal.Parse(strNumber);
                                    break;
                                case "Pub   L":
                                    row["L_Value"] = value ;
                                    break;
                            }
                        }
                    }
                }
            }
        }
    }
      
