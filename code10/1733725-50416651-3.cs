    public async Task<DataSet> ExecDataSetProcAsync(string qry, CancellationToken cancellationToken, params object[] args)
            {
                using (SqlCommand cmd = CreateCommand(qry, CommandType.StoredProcedure, args))
                {
                    DataSet ds = new DataSet();
    
                    await Task.Run(() =>
                    {
                        SqlDataAdapter adapt = new SqlDataAdapter(cmd);
                        cancellationToken.Register(() => cmd.Cancel());
    
                        try
                        {
                            adapt.Fill(ds);
                        }
                        catch (SqlException e)
                        {
                            // Canceling the sqlCommand causes an exception.  This is a workaround 
                            // to catch it, in case you don't want to be throwing the exception.
                            if (!cancellationToken.IsCancellationRequested)
                            {
                                throw e;
                            }
                        }
                    });
                    
                    return ds;
                }
            }
