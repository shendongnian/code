	command.CommandText = "SELECT [Password] FROM [Users] WHERE [Username] = @userName";
    // using DbCommand adds a lot more code than if you were to reference a non abstract implementation when adding parameters
    var param = command.CreateParameter();
    param.ParameterName = "@userName";
    param.Value = username_input.Text;
    param.DbType = DbType.String;
    param.Size = 100;
    command.Parameters.Add(param);
    // compared with SqlDbCommand which would be 1 line
    // command.Parameters.Add("@userName", SqlDbType.VarChar, 100).Value = username_input.Text;
	var result = command.ExecuteScalar()?.ToString();
	if(string.Equals(password_input.Text, result, StringComparison.Ordinal))
		MessageBox.Show("Logged in");
	else
		MessageBox.Show("Invalid Credentials!");
