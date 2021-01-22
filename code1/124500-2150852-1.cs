    using (var connection = new SqlConnection(Locale.sqlDataConnection))
    using (var command = new SqlCommand(preparedCommand, connection))
    using (var reader = command.ExecuteReader())
    {
        int stringColumnOrdinal = reader.GetOrdinal("SomeColumn");
        int dateColumnOrdinal = reader.GetOrdinal("SomeColumn2");
        int nullableIntColumnOrdinal = reader.GetOrdinal("SomeColumn3");
        while (reader.Read())
        {
            string var1 = reader.GetString(stringColumnOrdinal);
            DateTime var2 = reader.GetDateTime(dateColumnOrdinal);
            int? var3 = reader.IsDBNull(nullableIntColumnOrdinal) ? null : (int?)reader.GetInt32(nullableIntColumnOrdinal);
        }
    }
