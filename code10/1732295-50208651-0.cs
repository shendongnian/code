    public Task<DataSet> FilldataAsync(string ProcName, string TableName)
    {
        try
                {
                    return Task.Run(() =>
                    {
                        DataSet ds = new DataSet();
                        using (var da = new SqlDataAdapter(ProcName, con))
                        {
                            da.SelectCommand.CommandTimeout = 15000;
                            da.Fill(ds, TableName);
                            return ds;
                        }
                    });
                }
                catch (Exception ex)
                {
                    ErrorMsg = ex.Message.ToString();
                    HMISLogger.logger.Error(ex.Message.ToString() + " " + ProcName, ex);
                }
    }
