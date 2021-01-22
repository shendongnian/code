    using(var command = yourConnection.CreateCommand())
    {
       command.CommandText = "YOUR_SP_CALL(@PAR1, @PAR2)";
       command.CommandType = CommandType.StoredProcedure;
       command.Parameters.Add(new OdbcParameter("@PAR1", "lol"));
       command.Parameters.Add(new OdbcParameter("@PAR2", 1337));
       command.ExecuteNonQuery();
    }
