    private static DataTable ConvertCSVtoDataTable(string strFilePath)
            {
                DataTable dt = new DataTable();
                using (StreamReader sr = new StreamReader(strFilePath))
                {
                    string[] headers = sr.ReadLine().Split(',');
                    foreach (string header in headers)
                    {
                        dt.Columns.Add(header);
                    }
                    while (!sr.EndOfStream)
                    {
                        string[] rows = sr.ReadLine().Split(',');
                        DataRow dr = dt.NewRow();
                        for (int i = 0; i < headers.Length; i++)
                        {
                            dr[i] = rows[i];
                        }
                        dt.Rows.Add(dr);
                    }
    
                }
                
                return dt;
            }
    
            private static void WriteToDb(DataTable dt)
            {
                string connectionString =
                    "Data Source=localhost;" +
                    "Initial Catalog=Northwind;" +
                    "Integrated Security=SSPI;";
                
                using (SqlConnection con = new SqlConnection(connectionString))
                    {
                        using (SqlCommand cmd = new SqlCommand("spInsertTest", con))
                        {
                            cmd.CommandType = CommandType.StoredProcedure;
    
                            cmd.Parameters.Add("@policyID", SqlDbType.Int).Value = 12;
                            cmd.Parameters.Add("@statecode", SqlDbType.VarChar).Value = "blagh2";
                            cmd.Parameters.Add("@county", SqlDbType.VarChar).Value = "blagh3";
    
                            con.Open();
                            cmd.ExecuteNonQuery();
                        }
                    }
                
             }
