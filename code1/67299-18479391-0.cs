    static void Main()
            {
                string csv_file_path=@"C:\Users\Administrator\Desktop\test.csv";
    
                DataTable csvData = GetDataTabletFromCSVFile(csv_file_path);
    
                Console.WriteLine("Rows count:" + csvData.Rows.Count);
    
                Console.ReadLine();
            }
    
    
    private static DataTable GetDataTabletFromCSVFile(string csv_file_path)
            {
                DataTable csvData = new DataTable();
    
                try
                {
    
                using(TextFieldParser csvReader = new TextFieldParser(csv_file_path))
                    {
                        csvReader.SetDelimiters(new string[] { "," });
                        csvReader.HasFieldsEnclosedInQuotes = true;
                        string[] colFields = csvReader.ReadFields();
                        foreach (string column in colFields)
                        {
                            DataColumn datecolumn = new DataColumn(column);
                            datecolumn.AllowDBNull = true;
                            csvData.Columns.Add(datecolumn);
                        }
    
                        while (!csvReader.EndOfData)
                        {
                            string[] fieldData = csvReader.ReadFields();
                            //Making empty value as null
                            for (int i = 0; i < fieldData.Length; i++)
                            {
                                if (fieldData[i] == "")
                                {
                                    fieldData[i] = null;
                                }
                            }
                            csvData.Rows.Add(fieldData);
                        }
                    }
                }
                catch (Exception ex)
                {
                }
                return csvData;
            }
