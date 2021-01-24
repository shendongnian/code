    connection.Open();
    using (var command = connection.CreateCommand())
    {
        command.CommandText = @"CREATE TABLE #TemporaryTable ( [Value] INT );";
        command.CommandType = System.Data.CommandType.Text;
        command.ExecuteNonQuery();
    }
    using (var command = connection.CreateCommand())
    {
        command.CommandText = @"INSERT INTO #TemporaryTable ( [Value] ) SELECT CONVERT(INT, [value]) FROM STRING_SPLIT(@Array, ',');";
        command.CommandType = System.Data.CommandType.Text;
        command.Parameters.Add(new SqlParameter("@Array", string.Join(",", lstIds)));
        command.ExecuteNonQuery();
    }
    using (var command = connection.CreateCommand())
    {
        command.CommandText = @"SELECT COUNT(1) FROM #TemporaryTable";
        command.CommandType = System.Data.CommandType.Text;
        int count = Convert.ToInt32(command.ExecuteScalar());
    }
}
