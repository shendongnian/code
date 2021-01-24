    public void markComplete(int aTKey)
    {
        var sql = " UPDATE dbo.tb_bar " +
                   " SET    LastUpdateTime    = CONVERT(Time,GETDATE()) " +
                   " WHERE  AKey = @aTKey";
                   
        using(var myConnect = new SqlConnection(ConfigurationManager.ConnectionStrings["foo"].ConnectionString))
        {
            using(var mySqlCommand = new SqlCommand(sql, myConnect))
            {
                mySqlCommand.Parameters.Add("@aTKey", SqlDbType.Int).Value = aTKey;
                 
                RetryOnException(
                    () => {
                        mySqlCommand.Connection.Open();  
                        mySqlCommand.ExecuteNonQuery();
                    }, 3, 1000);
            }   
        }   
    }
