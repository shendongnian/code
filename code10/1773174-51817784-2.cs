    using (var conn = new SqlConnection(connectionstring))  
    {  
        conn.Open();
        using(var trans = conn.BeginTransaction())
        {
            try 
            {
                using(var comm = new SqlCommand("delete from FooBar where fooId = @foo", conn, trans))
                {
                    comm.Parameters.Add(new SqlParameter { ParameterName = "@foo", DbType = System.Data.DbType.Int32 });
                    for(int i = 0; i < 10 ; i++)
                    {
                        comm.Parameters["@foo"].Value = i;
                        comm.ExecuteNonQuery();
                    }
                }
                trans.Commit();
            }
            catch (Exception exe)
            {
                trans.Rollback();
                // do some logging
            }
        }
    } 
