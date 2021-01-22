    protected void EjecutarGuardar(string ProcedimientoAlmacenado, 
        Dictionary<string, object> Parametros)
    {
        using (SqlConnection Connection = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString))
        {
            SqlCommand Command = Connection.CreateCommand();             
            Command.CommandType = CommandType.StoredProcedure;
            foreach (string name in Parametros.Keys)
            {
                Command.Parameters.AddWithValue(name, Parametros[name]);
            }            
            Command.ExecuteNonQuery();
        }
    }
