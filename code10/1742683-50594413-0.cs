    List<User> userList = new List<User>() ;
    using (SqlConnection connection = new SqlConnection("string")
    {
    connection.Open();
    SqlCommand command = new SqlCommand("Select [Id], [UserName], [Password]. from [TaUser]", connection);
    using (SqlDataReader reader = command.ExecuteReader())
    {
        while (reader.Read())
        {
			var id = reader.GetInt32(0);
			var userName = reader.GetString(1);
			var pwd = reader.GetString(2);
			var user = new User(id, userName, pwd);
			userList.Add(user);
        }
    }
    connection.Close();
    // if you really need an array, do it here
    var al = userList.ToArray()
