		string sql = @"SELECT ImageData, ContentType, ImageName FROM UsersImage WHERE UserName = @UserName";
		using (var cn = new SqlConnection("[YOUR CONNECTION STRING]"))
		using (var cmd = new SqlCommand(sql, cn))
		{
			// Set some properties on the cmd object
			cmd.CommandType = CommandType.Text;
			cmd.Parameters.AddWithValue("@UserName", ThreadUserName);
			// Open the connection
			cn.Open();
			// Execute your command and get back a data reader
			using (var reader = cmd.ExecuteReader(CommandBehavior.CloseConnection))
			{
				if (reader.HasRows)
				{
					reader.Read();
					if (reader["ContentType"] != DBNull.Value)
					{
						ContentType = reader["ContentType"].ToString();
					}
					if (reader["ImageName"] != DBNull.Value)
					{
						ImageName = reader["ImageName"].ToString();
					}
					if (reader["ImageData"] != DBNull.Value)
					{
						ImageData = (byte[])reader["ImageData"];
					}
				}
			}
		}
