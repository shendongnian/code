       public void Commit()
        {
            using (SQLiteConnection conn = new SQLiteConnection(this.connString))
            {
                conn.Open();
                SQLiteTransaction trans = conn.BeginTransaction();
                try
                {
                    using (SQLiteCommand command = conn.CreateCommand())
                    {
                        command.Transaction = trans; // Now the command is linked to the transaction and don't try to create a new one (which is probably why your database gets locked)
                        command.CommandText = "INSERT OR IGNORE INTO [MY_TABLE] (col1, col2) VALUES (?,?)";
    
                        command.Parameters.Add(this.col1Param);
                        command.Parameters.Add(this.col2Param);
    
                        foreach (Data o in this.dataTemp)
                        {
                            this.col1Param.Value = o.Col1Prop;
                            this. col2Param.Value = o.Col2Prop;
    
                            command.ExecuteNonQuery();
                        }
                    }
                    trans.Commit();
                }
                catch (SQLiteException ex)
                {
                    // You need to rollback in case something wrong happened in command.ExecuteNonQuery() ...
                    trans.Rollback();
                    throw;
                }
            }
        }
