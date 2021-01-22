    string queryString = "SELECT * FROM tasks";
    OleDbConnection connection = new OleDbConnection(cn.ConnectionString);
    connection.Open(); // open connection first
    
    SqlCommand cmd = new SqlCommand(queryString, connection);
    OleDbDataAdapter adapter = new OleDbDataAdapter(cmd); // use the cmd above when instantiating the adapter
    OleDbCommandBuilder builder = new OleDbCommandBuilder(adapter);
    
    adapter.Fill(ds.Tables["Tasks"]);                      
    
    // Modify your dataset here.
    // Don't call AcceptChanges() as this will prevent the update from working.
    
    adapter.Update(ds);
    
    connection.Close(); // Close connection before ending the function
    
    return ds;
