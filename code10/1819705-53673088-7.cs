    protected DataSet ExecuteDataSet(string StoredProcName, IEnumerable<TParameter> Params = null) 
    {  
        DataSet resultDataSet = new DataSet(); 
        if (transaction == null)
        { 
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
                adapter.Fill(resultDataSet);
            }
        }
        else
        {
            using (var cmd = new TCommand(StoredProcName, transaction.Connection))
            using (var adapter = new TAdapter(cmd))
            {
                cmd.Transaction = transaction;
                cmd.CommandType = CommandType.StoredProcedure;
                if (Params != null) 
                {
                    foreach (TParameter param in Params)
                    {
                        cmd.Parameters.Add(param);
                    }
                }    
                adapter.Fill(resultDataSet);
            }
        }
        return resultDataSet; 
    }
