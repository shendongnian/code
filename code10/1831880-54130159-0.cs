	using (var con = (OracleConnection)db.Server.GetConnection())
	{
		con.Open();
		//string pw = "'''';++";
		string pw = "newpass";
		var cmd = new OracleCommand(@"
	BEGIN
	EXECUTE IMMEDIATE CONCAT('ALTER USER B identified by ',:pw);
	END;", con);
		cmd.CommandType = CommandType.Text;
		
		var p2 = cmd.CreateParameter();
		p2.ParameterName = "pw";
		p2.Value = pw;
		p2.DbType = DbType.String;
		cmd.Parameters.Add(p2);
		cmd.ExecuteNonQuery();
	}
