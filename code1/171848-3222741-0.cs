            public static void CreateCsvFile(DataTable dt, string strFilePath, bool exportColumnHeaders)
            {
                using (StreamWriter sw = new StreamWriter(strFilePath, false, Encoding.UTF8))
                {
                    int iColCount = dt.Columns.Count;
    
                    if (exportColumnHeaders)
                    {
                        for (int i = 0; i < iColCount; i++)
                        {
                            sw.Write("\"" + dt.Columns[i] + "\"");
    
                            if (i < iColCount - 1)
                                sw.Write(",");
                        }
    
                        sw.Write(sw.NewLine);
                    }
    
                    foreach (DataRow dr in dt.Rows)
                    {
                        for (int i = 0; i < iColCount; i++)
                        {
                            if (!Convert.IsDBNull(dr[i]))
                                sw.Write("\"" + dr[i] + "\"");
    
                            if (i < iColCount - 1)
                                sw.Write(",");
                        }
    
                        sw.Write(sw.NewLine);
                    }
    
                    sw.Close();
                }
            }
