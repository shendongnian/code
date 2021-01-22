    protected void EjecutarGuardar(string ProcedimientoAlmacenado, 
        Dictionary<string, object> Parametros)
    {
        using (SqlConnection Connection = new SqlConnection(...))
        {
            Connection.Open();
            SqlCommand Command = Connection.CreateCommand()
            Command.CommandText = ProcedimientoAlmacenado;
            Command.Connection = Connection;       
            Command.CommandType = CommandType.StoredProcedure;
            foreach (string name in Parametros.Keys)
            {
              Command.Parameters.AddWithValue(name, Parametros[name] ?? DBNull.Value);
            }            
            Command.ExecuteNonQuery();
        }
    }
