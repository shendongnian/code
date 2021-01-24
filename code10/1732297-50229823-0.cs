     public DataSet Filldata(string ProcName, string TableName)
            {
                DataSet ds = new DataSet();
                try
                {
    
                    da = new SqlDataAdapter(ProcName, con);
                    da.SelectCommand.CommandTimeout = 15000;
                    lock (lockObj)
                    {
                        da.Fill(ds, TableName);
                    }
                }            
                catch (Exception ex) {
                    ErrorMsg = ex.Message.ToString();
                    HMISLogger.logger.Error(ex.Message.ToString() + " " + ProcName, ex);
                }
                finally {
                    con.Close();
                    da.Dispose();
                }
                return ds;
            }
    
