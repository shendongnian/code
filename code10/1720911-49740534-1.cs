	using(var db = new Npgsql.NpgsqlConnection("CONNECTIONSTRING")) {
		db.Open();		
		db.MapComposite<Test>("test");			
		db.QueryFirst<Test>("receive_test", new
		{
			_row = new CompositeParameter<Test>(new Test()
			{
				A = 1,
				B = "string"
			})
		}, commandType: CommandType.StoredProcedure).Dump();
	}
