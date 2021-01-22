    try
    {
        using (var conn = new SqlConnection(/* connection string or whatever */))
        {
            conn.Open();
    
            using (var trans = conn.BeginTransaction())
            {
                try
                {
                    using (var cmd = conn.CreateCommand())
                    {
                        cmd.Transaction = trans;
                        /* setup command type, text */
                        /* execute command */
                    }
                    trans.Commit();
                }
                catch (Exception ex)
                {
                    trans.Rollback();
                    /* log exception and the fact that rollback succeeded */
                }
            }
        }
    }
    catch (Exception ex)
    {
        /* log or whatever */
    }
