    public DataTable ReadExcel(string fileName)
            {
                string fileExt = ".xlsx";
                string sheetName = "Sheet1$";
                string conn = string.Empty;
                DataTable dt = new DataTable();
                if (fileExt.CompareTo(".xlsx") != 0)
                    conn = @"provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + fileName + ";Extended Properties='Excel 8.0;HRD=Yes;IMEX=1';"; //for below excel 2007  
                else
                    conn = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + fileName + ";Extended Properties='Excel 12.0 Xml;HDR=YES';"; //for above excel 2007  
                using (OleDbConnection con = new OleDbConnection(conn))
                using ( OleDbCommand cmd = new OleDbCommand())            
                {
                    con.Open();
                    try
                    {
                        cmd.Connection = con;                   
                        cmd.CommandText = "SELECT * FROM [" + sheetName + "]";                     
                        dt.TableName = sheetName;
    
                        using (OleDbDataAdapter da = new OleDbDataAdapter(cmd))
                        {
                            da.Fill(dt);
                        }
                        
                    }
                    catch (Exception ex) { }
                }
                return dt;
            }
