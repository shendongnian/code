     using (SQLiteConnection conn = new SQLiteConnection(connectionString))
                {
                    //Open connection to DB
                    conn.Open(); 
                    //Query to be fired                   
                    string sql = "Your Query to insert rows";
                    //Executing the query
                    using (SQLiteCommand cmd = new SQLiteCommand(sql, conn))
                    {
                        //Executing the query                    
                        cmd.CommandText = sql;
                        cmd.ExecuteNonQuery();
                    }
                    //Close connection to DB
                    conn.Close();
                }
