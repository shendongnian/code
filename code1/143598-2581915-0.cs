        OleDbConnection connection= new OleDbConnection(connectionstring);
        string addSheet= "CREATE TABLE Mus(id nvarchar(255), name nvarchar(5))";
        connection.Open();
        OleDbCommand sqlcommand = new OleDbCommand(addSheet,connection);
        sqlcommand.ExecuteNonQuery();
        connection.Close();
