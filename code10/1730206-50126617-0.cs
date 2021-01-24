    public virtual async Task<bool> Notify(SMSNotification request)
    {
        using (var sql = _sqlMapper.CreateCommand('Database', 'Stored proc'))
        {
            sql.AddParam("@fMessage", request.Message);
           //..............
           //.............. more params
            var retvalParamOutput = sql.AddOutputParam("@fRetVal", System.Data.SqlDbType.Int);
            await sql.ExecuteAsync();
            return retvalParamOutput.GetSafeValue<int>() == 1;
        }
    }
