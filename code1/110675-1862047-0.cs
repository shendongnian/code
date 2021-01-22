    try { sql_conn.Open(); }
                catch (Exception)
                {
                    if (sql_conn.State != ConnectionState.Closed)
                    {
                        sql_conn.Close();
                        sql_conn.Open();
                    }
                }
