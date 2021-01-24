                try
                {
                    using (IDataReader dr = db.ExecuteReader(cmd))
                    {
                        while (dr.Read())
                        {
                            // do something with the data
                        }
                    }
                }
                catch (Exception e)
                {
                    // exception handling
                }
