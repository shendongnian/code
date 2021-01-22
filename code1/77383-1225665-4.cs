    using System;
    using System.Data;
    using System.IO;
    using System.Text.RegularExpressions;
    
    namespace GeneralTestApplication
    {
        class Program
        {
            private static void Main()
            {
                String input = @"<root><Table> [...] </root>";
                input = Regex.Replace(input, @" [a-zA-Z]+=""[^""]*""", String.Empty);
                
                DataSet dataSet = new DataSet();
    
                dataSet.ReadXml(new StringReader(input));
    
                foreach (DataRow row in dataSet.Tables[0].Rows)
                {
                    foreach (DataColumn column in dataSet.Tables[0].Columns)
                    {
                        Console.Write(row[column] + " | ");
                    }
                    Console.WriteLine();
                }
    
                Console.ReadLine();
            }
        }
    }
