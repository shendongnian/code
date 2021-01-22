    SqlConnection myConnection = new SqlConnection(myConnectionString);
    SqlCommand myCommand = new SqlCommand(mySelectQuery, myConnection);
    myConnection.Open();
    SqlDataReader myReader = myCommand.ExecuteReader(CommandBehavior.CloseConnection);
    while(myReader.Read()) 
    {
       Console.WriteLine(myReader.GetString(0));
    }
    myReader.Close();
