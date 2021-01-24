    public Task<DataSet> GetDataSetAsync(string sConnectionString, string sSQL, params SqlParameter[] parameters)
    {
        return Task.Run(() =>
        {
            using (var newConnection = new SqlConnection(sConnectionString))
            using (var mySQLAdapter = new SqlDataAdapter(sSQL, newConnection))
            {
                mySQLAdapter.SelectCommand.CommandType = CommandType.Text;
                if (parameters != null) mySQLAdapter.SelectCommand.Parameters.AddRange(parameters);
    
                DataSet myDataSet = new DataSet();
                mySQLAdapter.Fill(myDataSet);
                return myDataSet;
            }
        });
    }
