	using (var conn = new OleDbConnection(connectionStringHere))
	using (var cmd = conn.CreateCommand())
	{
		cmd.CommandText = "INSERT INTO Users([UserCode],[UserName],[UserID],[Password],[Designation],[ContactNo],[UserType]) VALUES (?,?,?,?,?,?,?)";
		cmd.Parameters.Add(new OleDbParameter("?", OleDbType.VarChar, 100) {Value = txtUserCode.Text});
		cmd.Parameters.Add(new OleDbParameter("?", OleDbType.VarChar, 100) {Value = txtUserName.Text});
		cmd.Parameters.Add(new OleDbParameter("?", OleDbType.VarChar, 100) {Value = txtUserID.Text});
		cmd.Parameters.Add(new OleDbParameter("?", OleDbType.VarChar, 100) {Value = txtPassword.Text});
		cmd.Parameters.Add(new OleDbParameter("?", OleDbType.VarChar, 100) {Value = txtDesignation.Text});
		cmd.Parameters.Add(new OleDbParameter("?", OleDbType.Integer) {Value = int.Parse(txtContactNo.Text) });
		cmd.Parameters.Add(new OleDbParameter("?", OleDbType.VarChar, 100) {Value = cboxUserType.Text});
		conn.Open();
		var numberOfRowsInserted = cmd.ExecuteNonQuery();
	}
