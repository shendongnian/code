                    dr = dt.NewRow();
                    DatabaseRow_Set(ref dr, Data);
                    dt.Rows.Add(dr);                
                    //
                    // Update the DataSet with the Database
                    //
                    cb = new MySqlCommandBuilder da);                                                
                    da.Update(dt);                
    
                    MySqlCommand cmd = new MySqlCommand("select LAST_INSERT_ID()", Connection);
                    long ID = ((long) cmd.ExecuteScalar());
                    DatabaseRow_GetID(ref Data, ID);                
