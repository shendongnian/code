    string connectionString = "my connection string";
    
    
    
                for (int i = 0; i < dataGridView1.RowCount - 1; i++)
                {
                    DataGridViewRow row = dataGridView1.Rows[i];
                   
                    SqlConnection conn = new SqlConnection(connectionString);
                    conn.Open();
    
                    try
                    {
    
                        var queryString = "INSERT INTO [SQLdb] " +
                            "(columnNamesInDB) " +
                            "VALUES (@dataBeingRead)";
                        SqlCommand comm = new SqlCommand(queryString, conn);
                        comm.ExecuteNonQuery();
                        comm.Close();
                      }
    catch (Exception e)
    {
    //catch behavior
    }
