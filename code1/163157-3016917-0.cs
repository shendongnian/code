    SqlConnectionStringBuilder builder = new SqlConnectionStringBuilder();
    builder.DataSource = Server;
    builder.UserID = Username;
    builder.Password = Password;
    builder.InitialCatalog = Database;
    SqlConnection SQLConnection = new SqlConnection(builder.ToString());
    try {
        SQLConnection.Open();
        ...
    } finally {
        SQLConnection.Close();        
    }
