    using (var cmd = conn.CreateCommand())
    {
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.CommandText = "foo";
        // if SingleResult is omitted, the error is observed
        // using (var reader = cmd.ExecuteReader())
        // if SingleResult is specified, the error is not observed
        using (var reader = cmd.ExecuteReader(CommandBehavior.SingleResult))
        {
            do
            {
                while (reader.Read()) { } // ignore the rows in the grid
            } while (reader.NextResult());
        }
    }
