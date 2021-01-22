        try
            {
               using (var Connection = new NpgsqlConnection(PG_Connection_String))
               NpgsqlDataAdapter da = new NpgsqlDataAdapter("myQuery", connectionString))
     {
                        Connection.Open();
    
                        myTable = new System.Data.DataTable();
                        da.Fill(myTable);
    
                        postgresql_dataGrid.DataSource = myTable.DefaultView;
    
                        Connection.Close();
                    }
                }
                catch (Exception Ex)
                {
                    MessageBox.Show("Your Error", "Connection Error");
                }
            }
