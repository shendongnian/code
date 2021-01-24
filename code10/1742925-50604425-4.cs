    string myConnectionString = FetchDbConnectionString(environment, item);
    MySqlConnection mySqlConnection = new MySqlConnection(myConnectionString);
    string SQLC= "Select * From openingclosingstock Where CreateDate <= _endDate 
    order by CreateDate asc;"
    MySqlCommand mySqlCommand = new 
    MySqlCommand(SQLC, mySqlConnection);
    await mySqlConnection.OpenAsync();
    var reader = await mySqlCommand.ExecuteReaderAsync();
    while (await reader.ReadAsync())
    {
        //do something
    }
    reader.Close();
    await mySqlConnection.CloseAsync();
