    public void CreateCSVFile(DataTable dt, string strFilePath,string separator)
            {
               
                #region Export Grid to CSV
                // Create the CSV file to which grid data will be exported.
    
                StreamWriter sw = new StreamWriter(strFilePath, false);
    
    
                int iColCount = dt.Columns.Count;
    
    
                for (int i = 0; i < iColCount; i++)
                {
    
                    sw.Write(dt.Columns[i]);
    
    
                    if (i < iColCount - 1)
                    {
    
    
                        sw.Write(separator);
    
    
                    }
    
    
                }
    
    
                sw.Write(sw.NewLine);
    
    
                // Now write all the rows.
    
    
                foreach (DataRow dr in dt.Rows)
                {
    
    
                    for (int i = 0; i < iColCount; i++)
                    {
    
    
                        if (!Convert.IsDBNull(dr[i]))
                        {
    
    
                            sw.Write(dr[i].ToString());
    
    
                        }
    
    
                        if (i < iColCount - 1)
                        {
    
    
                            sw.Write(separator);
    
    
                        }
    
    
                    }
    
    
                    sw.Write(sw.NewLine);
    
    
                }
    
    
                sw.Close();
    
                #endregion
    
    
            }
