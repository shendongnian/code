               try
               {
                    using (SqlConnection con = new SqlConnection(GetRemoteConnectionString()))
                    {
                        con.Open();
                    }
                    success = true;
                }
                catch (Exception ex)
                {
                   success = false;
                    ...
                }
