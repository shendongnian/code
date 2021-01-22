    SqlCommand Command = Connection.CreateCommand();
    Command.CommandText = ProcedimientoAlmacenado;
    Command.CommandType = CommandType.StoredProcedure;
    foreach (object X in Parametros)
    {
        SqlParameter param = new SqlParameter();
        param.ParameterName = Parametros.Name;
        // you need to find a way to determine what DATATYPE the
        // parameter will hold - Int, VarChar etc.
        param.SqlDbType = SqlDbType.Int;  
        param.Value = Parametros.Value;
        Command.Parameters.Add(param);
    }           
