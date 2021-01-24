    private void save_changes(string sequelQueryString, DataGridView given_grid_view) /* master save method that initializes a new Data Adapter based on given sequel string 
                                                                                             that saves any changes inputted into the given grid view */
                                                                                             
        {
            using (MySqlConnection mysqlConn = new MySqlConnection(db_connection))
            {
                mysqlConn.Open();
                sqlData = new MySqlDataAdapter(sequelQueryString, mysqlConn);
                sqlCommandBuilder = new MySqlCommandBuilder(sqlData);
                var current_data_table = (DataTable)given_grid_view.DataSource; // if any changes occur in given grid view db table is updated when a "SAVE" button is clicked
                sqlData.Update(current_data_table);
            }
        }
 
