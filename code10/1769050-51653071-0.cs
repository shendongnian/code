    var conn = new OdbcConnection();
                conn.ConnectionString =
                              @"Driver={SQL Server};" +
                             @"Server=EGC25199\SQL2016;" +
                              @"DataBase=LegOgSpass;" +
                              @"Trusted_Connection=Yes;";
             
    
                try
                {
                    string cmdString = "CREATE TABLE dbo.odbctable (Wartosc int, Czas datetime)";                                         
                    conn.Open();
    
                    using (OdbcCommand cmd = new OdbcCommand(cmdString, conn))
                    {
                        cmd.ExecuteNonQuery();
                        conn.Close();
                    }
                    
                }
    
                catch (Exception ex)
                {
                    Console.WriteLine(ex);
                }
