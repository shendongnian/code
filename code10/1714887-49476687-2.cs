    using System;
    using System.Collections.Generic;
    using System.Collections;
    using System.Linq;
    using System.Text;
    using System.Data;
    using System.IO;
    namespace ConsoleApplication1
    {
        class Program
        {
            static void Main(string[] args)
            {
                string csv_file_path = @"C:\Sample files";
                DataTable csvData = new DataTable();
                string[] files = Directory.GetFiles(csv_file_path, "*.csv");
                Boolean firstFile = true;
                foreach (string file in files)
                {
                    GetDataTabletFromCSVFile(file, csvData, firstFile);
                    firstFile = false;
                }
                
           
                  
            private static void GetDataTabletFromCSVFile(string csv_file_path, DataTable csvData, Boolean firstFile)
            {
                
                try
                {
                    int lineCount = 0;
                    using (StreamReader  csvReader = new StreamReader(csv_file_path))
                    {
                        string line = "";
                        while ((line = csvReader.ReadLine()) != null)
                        {
                            string[] colFields = line.Split(new char[] { ',' }).ToArray();
                            if (++lineCount == 1)
                            {
                                if (firstFile)
                                {
                                    //read column names
                                    foreach (string column in colFields)
                                    {
                                        csvData.Columns.Add(column, typeof(string));
                                    }
                                }
                            }
                            else
                            {
                                //Making empty value as null
                                for (int i = 0; i < colFields.Length; i++)
                                {
                                    if (colFields[i] == "")
                                    {
                                        colFields[i] = null;
                                    }
                                }
                                csvData.Rows.Add(colFields);
                            }
                        }
                    }
                }
                catch (Exception)
                {
                }
            }
        }
    }
