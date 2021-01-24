    public static void WriteDataToFile(DataTable submittedDataTable, string submittedFilePath)
            {
                int i = 0;
                StreamWriter sw = null;
    
                sw = new StreamWriter(submittedFilePath, false);
    
                for (i = 0; i < submittedDataTable.Columns.Count - 1; i++)
                {
    
                    sw.Write(submittedDataTable.Columns[i].ColumnName + ";");
    
                }
                sw.Write(submittedDataTable.Columns[i].ColumnName);
                sw.WriteLine();
    
                foreach (DataRow row in submittedDataTable.Rows)
                {
                    object[] array = row.ItemArray;
    
                    for (i = 0; i < array.Length - 1; i++)
                    {
                        sw.Write(array[i].ToString() + ";");
                    }
                    sw.Write(array[i].ToString());
                    sw.WriteLine();
    
                }
    
                sw.Close();
            }
