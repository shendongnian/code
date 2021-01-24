    using (var conn = new NpgsqlConnection("connection-string"))
	{
		using (var command = new NpgsqlCommand("Select * from encaissement", conn))
		{
			conn.Open();
			using (NpgsqlDataReader reader = command.ExecuteReader())
			{
				while (reader.Read())
				{
					var encaiss = new Encaissement();
					encaiss.id = reader.GetInt32(0);
					encaiss.mode_paiemant = reader.GetString(2);
					encaiss.num_fact = reader.GetString(9);
					ListEncaissement.Add(encaiss);
				}
			}
		}
		using (var command = new NpgsqlCommand("Select * from borne", conn))
		{
			using (NpgsqlDataReader reader = command.ExecuteReader())
			{
				while (reader.Read())
				{
					var b = new Borne();
					b.id = reader.GetInt32(0);
					b.nom = reader.GetString(2);
					ListeBorne.Add(b);
				}
			}
		}
	}
