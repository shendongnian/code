			using (var cmd = new MySqlCommand("select user_login from wp_users where user_login = @user and user_pass = @pass", conn))
			{
				conn.Open();
		
				// Set parameters
				cmd.Parameters.AddWithValue("@user", user);
				cmd.Parameters.AddWithValue("@pass", pass);
		
				// Get result
				using (var reader = cmd.ExecuteReader(CommandBehavior.SingleRow))
				{
					// If ANY row, there is a user
					if (reader.Read())
					{
						// Login succesfull
					} 
					else
					{
						// Login failed
					}
				}
			}
