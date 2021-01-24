	OleDbConnection connection = new OleDbConnection();
	connection.ConnectionString = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=F:\WebSites\MyWebsite\DataBase.mdb;Persist Security Info=False;";
	try
	{
		connection.Open();
		OleDbCommand command = new OleDbCommand();
		command.Connection = connection;
		command.CommandText = "insert into users (FirstName, LastName, Place, Email, UserName, Birthday) values(@firstName, @lastName, @placeList, @myMail, @accountText, @date)";
		command.Parameters.AddWithValue("@firstName", firstName.Text);
		command.Parameters.AddWithValue("@lastName", lastName.Text);
		command.Parameters.AddWithValue("@placeList", placeList.Text);
		command.Parameters.AddWithValue("@myMail", myMail.Text);
		command.Parameters.AddWithValue("@accountText", accountText.Text);
		command.Parameters.AddWithValue("@date", date.Text);
		command.ExecuteNonQuery();
	}
	/* handle various exceptions */
	catch (Exception ex)
	{
		/*...*/
	}
	finally
	{
		connection.Close();
	}
