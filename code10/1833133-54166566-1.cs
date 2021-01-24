	using (var conn = GetConnection())
	{
		using (var cmd = conn.CreateCommand())
		{
			//Construct a valid SQL statement that joins questions to tags
			cmd.CommandText = "SELECT q.*, t.* FROM questions q JOIN tags t ON 1 = 1";
			using (var reader = cmd.ExecuteReader())
			{
				while (reader.Read())
				{
					data.Add(new
					{
						QestionId = reader.IsDBNull(0) ? 0 : int.TryParse(reader.GetValue(0).ToString(), out var qId) ? qId : 0,
						Title = reader.IsDBNull(1) ? string.Empty : reader.GetValue(1).ToString(),
						Description = reader.IsDBNull(2) ? string.Empty : reader.GetValue(2).ToString(),
						TagId = reader.IsDBNull(3) ? 0 : int.TryParse(reader.GetValue(3).ToString(), out var tId) ? tId : 0,
						Name = reader.IsDBNull(4) ? string.Empty : reader.GetValue(4).ToString()
					});
				}
			}
		}
	}
