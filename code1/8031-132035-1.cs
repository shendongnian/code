    SQLCommand getTimeCommand = new SQLCommand("SELECT time FROM table", dbConnection);
    SQLDataReader myReader = getTimeCommand.ExecuteReader();
    while (myReader.Read())
    {
        DateTime time = myReader.GetDateTime(0);
    }
    myReader.Close();
