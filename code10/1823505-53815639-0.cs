    public List<Package> getPackages()
		{
			var conn = new MySqlConnection("server = localhost; user id = root; database=assignment_four; password=Mysqlpassword123");
			var packages = new List<Package>();
			try
			{
				conn.Open();
				using (var cmd = conn.CreateCommand())
				{
					cmd.CommandText = "SELECT * from packages";
					using (var reader = cmd.ExecuteReader())
					{
						while (reader.Read())
						{
							packages.Add(new Package(
								reader.GetInt32(reader.GetOrdinal("id")),
								reader.GetString(reader.GetOrdinal("name")),
								reader.GetString(reader.GetOrdinal("description")),
								reader.GetBoolean(reader.GetOrdinal("tracking")),
								reader.GetInt32(reader.GetOrdinal("senderCity_id")),
								reader.GetInt32(reader.GetOrdinal("destinationCity_id")),
								reader.GetInt32(reader.GetOrdinal("sender_id")),
								reader.GetInt32(reader.GetOrdinal("receiver_id"))
							));
						}
						reader.Close();
					}
				}
			}
			catch (Exception exp)
			{
				throw;
			}
			finally
			{
				conn.Close();
			}
			return packages;
		}
