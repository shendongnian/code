    SqlConnection mySqlConnection = ConnectDB();
    SqlCommand mySqlCommand = mySqlConnection.CreateCommand();
    mySqlCommand.CommandText =
       @" 
          SQL QUERY HERE
       ";
    mySqlConnection.Open();
    mySqlCommand.ExecuteNonQuery();
    mySqlConnection.Close();
