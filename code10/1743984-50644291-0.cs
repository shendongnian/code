	using(var trans = db.BeginTransaction())
	using(var cmd = db.CreateCommand()) {			
		cmd.CommandText = "sp_get_multiviewlist";
		cmd.CommandType = CommandType.StoredProcedure;	
		
		string cursor1Name,cursor2Name;
		using (var reader = cmd.ExecuteReader())
		{
			reader.Read();
			cursor1Name = reader.GetString(0);
			reader.Read();
			cursor2Name = reader.GetString(0);
		}
				
		
		using(var resultSet1 = db.CreateCommand())
		{
			resultSet1.CommandText = $@"FETCH ALL FROM ""{cursor1Name}""";
			using (var reader = resultSet1.ExecuteReader())
			{
				while (reader.Read())
				{
					// Do something with the customer row
				}
			}
		}
		using (var resultSet2 = db.CreateCommand())
		{
			resultSet2.CommandText = $@"FETCH ALL FROM ""{cursor2Name}""";
			using (var reader = resultSet2.ExecuteReader())
			{
				while (reader.Read()) {
					// Do something with the order row
				}
			}
		}
	}
		
