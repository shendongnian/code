                using (SqlCommand cmd = new SqlCommand(cmdText, conn))
                {
                    cmd.CommandType = type;
                    if (prms != null)
                    {
                        foreach (SqlParameter p in prms)
                        {
                            cmd.Parameters.Add(p);
                        }
                    }
                    conn.Open();
                    return cmd.ExecuteNonQuery();
                }
            }
        }
