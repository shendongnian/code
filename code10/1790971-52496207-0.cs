	using (var dr = cmd.ExecuteReader())
	{
		var testCol1Idx = dr.GetOrdinal("testCol1");
		var testCol2Idx = dr.GetOrdinal("testCol2");
		var testCol3Idx = dr.GetOrdinal("testCol3");
		var testCol4Idx = dr.GetOrdinal("testCol4");
		var testCol5Idx = dr.GetOrdinal("testCol5");
		while (dr.Read())
		{
			inputs.Add(new TestData()
			{
				testCol1 = dr.GetInt32(testCol1Idx);
				testCol2 = dr.GetInt32(testCol2Idx);
				testCol3 = dr.GetString(testCol3Idx);
				testCol4 = dr.GetDouble(testCol4Idx);
				testCol5 = dr.GetInt32(testCol5Idx);
			});
		}
	}
