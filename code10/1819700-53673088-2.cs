    protected DataSet ExecuteDataSet(string StoredProcName, IEnumerable<TParameter> Params = null) 
    {    
        DataSet resultDataSet = new DataSet();
        using (var cn = new TConnection(connection.ConnectionString)) /
        using (var cmd = new TCommand(StoredProcName, cn))
        using (var adapter = new TAdapter(cmd))
        {
            cmd.CommandType = CommandType.StoredProcedure;
   
            if (Params != null) 
            {
                foreach (TParameter param in Params)
                {
                    cmd.Parameters.Add(param);
                }
            }    
            dataAdapter.Fill(resultDataSet);
        }
        return resultDataSet;        
    }
