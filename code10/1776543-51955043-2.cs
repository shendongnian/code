    using (SqlConnection conn = new SqlConnection(_connectionString))
	{
        return conn
            .Query<int, string, string, KeyValuePair<int, dynamic>>(
                "SELECT 1 AS 'SomeInt', 'A' AS 'SomeString', 'True' AS 'SomeBool'",
                (i, s, b) =>
                    new KeyValuePair<int, dynamic>(
                        i,
                        new
                        {
                            TheString = s,
                            TheBool = Convert.ToBoolean(b)
                        }),
                splitOn: "SomeInt,SomeString,SomeBool")
            .AsList();
	}
