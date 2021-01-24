            private void fill_given_grid_view (string sequelQueryString, DataGridView given_grid_view) /* master method that takes an SQL query and grid view as input 
                                                                                                      and displays a table accordingly */
                                              
        {
            using (MySqlConnection mysqlConn = new MySqlConnection(db_connection)) // using stored connection params
            {
                mysqlConn.Open();
                sqlData = new MySqlDataAdapter(sequelQueryString, mysqlConn);
                sqlCommandBuilder = new MySqlCommandBuilder(sqlData);
                dataTable = new DataTable(); // new dataTable created, filled based on given query and set as the DataSource of the grid given as input to the method
                sqlData.Fill(dataTable);
                given_grid_view.DataSource = dataTable;
            }
        }
