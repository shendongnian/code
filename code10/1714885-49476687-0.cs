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
                    GetDataTabletFromCSVFile(csv_file_path, csvData, firstFile);
                    firstFile = false;
                }
                //performing the operations
                Program p = new Program();
                object  med= p.GetMedianFromDataTable(csvData, "Data Value");
                Console.WriteLine("median={0}", med);
                double med1=Convert.ToDouble(med)*0.20;
                ArrayList al = new ArrayList(); //arraylist creating which will have value 20% more than the median
                ArrayList a2 = new ArrayList(); //arraylist creating which will have value 20% less than the median
                Console.WriteLine("-----values 20% more than median are--------");
                foreach(DataRow row in csvData.Rows)
                {
                    if( Convert.ToDouble(row["Data Value"])>med1)
                    {
                         al.Add(Convert.ToDouble(row["Data Value"]));
                        //Console.WriteLine("value greater than 20 % median= {0}", Convert.ToDouble(row["Data Value"]));
                    }
                }
                foreach(object obj in al) //printing values that are more than median
                {
                    Console.WriteLine(obj);
                }
                Console.WriteLine("-----values 20% less than median are--------");
                foreach (DataRow row in csvData.Rows)
                {
                    if (Convert.ToDouble(row["Data Value"]) < med1)
                    {
                        a2.Add(Convert.ToDouble(row["Data Value"]));
                        //Console.WriteLine("value greater than 20 % median= {0}", Convert.ToDouble(row["Data Value"]));
                    }
                }
                foreach (object obj in a2) //printing values that are 20% less than the median
                {
                    Console.WriteLine(obj);
                }
              Console.ReadLine();
            }
            public  object GetMedianFromDataTable(DataTable dt, string columnName)
            {
                double ing;
                double[] values = dt.Rows.OfType<DataRow>()
                     .Select(dr => dr[columnName].ToString())
                     .Where(v => double.TryParse(v, out ing))
                     .Select(v => double.Parse(v))
                     .ToArray();
                return GetMedianFromArray(values);
            }
            public double GetMedianFromArray(double[] values)
            {
                double median;
                //sort the array
                Array.Sort(values);
                if (values.Length % 2 != 0)
                {
                    median = values[values.Length / 2];
                }
                else
                {
                    int middle = values.Length / 2;
                    Double first = values[middle];
                    double second = values[middle - 1];
                    median = (first + second) / 2;
                }
                return median;
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
