	string MyConString = "SERVER=localhost;" +
		"DATABASE=mydatabase;" +
		"UID=testuser;" +
		"PASSWORD=testpassword;";
	MySqlConnection connection = new MySqlConnection(MyConString);
	MySqlCommand command = connection.CreateCommand();
	MySqlDataReader Reader;
	command.CommandText = "select * from mycustomers";
	connection.Open();
	Reader = command.ExecuteReader();
	while (Reader.Read())
	{
		string thisrow = "";
		for (int i= 0;i<Reader.FieldCount;i++)
				thisrow+=Reader.GetValue(i).ToString() + ",";
		listBox1.Items.Add(thisrow);
	}
	connection.Close();
