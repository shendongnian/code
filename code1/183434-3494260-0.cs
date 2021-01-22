    using MySql.Data.MySqlClient;
    
    string myConnectionString = "SERVER=localhost;" +
                                "DATABASE=mydatabase;" +
                                "UID=user;" +
                                "PASSWORD=mypassword;";
     
    MySqlConnection connection = new MySqlConnection(myConnectionString);
    MySqlCommand command = connection.CreateCommand();
    command.CommandText = "SHOW TABLES;";
    MySqlDataReader Reader;
    connection.Open();
    Reader = command.ExecuteReader();
    while (Reader.Read())
    {
        string row = "";
        for (int i = 0; i < Reader.FieldCount; i++)
            row += Reader.GetValue(i).ToString() + ", ";
        Console.WriteLine(row);
    }
    connection.Close();
 
