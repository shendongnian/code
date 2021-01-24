    var command = connection.CreateCommand();
    command.CommandText = "insert into myTable (colA, colB) values (:ColA, :ColB)";
    command.Parameters.Add("ColA", OracleDbType.Int64, ParameterDirection.Input);
    command.Parameters.Add("ColB", OracleDbType.Int64, ParameterDirection.Input);
    
    foreach ( var entry in mydict ) {
       command.Parameters["ColA"].Value = entry.Key;
       command.Parameters["ColA"].Value = entry.Value;
       command.ExecuteNonQuery();
    }
    
