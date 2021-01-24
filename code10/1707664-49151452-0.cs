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
                 
                var success = false;
                var attempts = 0;
                do
                {
                    attempts++;
                    try
                    {
                        mySqlCommand.Connection.Open();        //<<<<<<<< EXCEPTION HERE <<<<<<<<<<<<<<<<<<
                        mySqlCommand.ExecuteNonQuery();
                        success = true;
                    }
                    catch(Exception ex)
                    {
                        // Log exception here
                        Threading.Thread.Sleep(1000);
                    }
                }while(attempts == 3 || !success);
            }   
        }   
    }
