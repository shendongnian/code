    public void MyMethod(IDbTransaction sharedTransaction, DateTime eventTime)
    {
        DateTime lastEventTime;
        using (var cmd = (SqlCommand)sharedTransaction.Connection.CreateCommand())
        {
            cmd.CommandText = "somecmdtext";
            cmd.Parameters.AddWithValue("ParamName", 123);
        
            object oResult = dbUtility.ExecuteScalar(cmd);
        
            lastEventTime = DateTime.Parse(oResult.ToString());
        }
        
        //Do something with dtLastEventTime
        lastEventTime += TimeSpan.FromMinutes(1);
    }
