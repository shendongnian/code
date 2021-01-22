    protected void ExecuteSproc(string name,
                                SqlDbType? returnType,
                                Action<SqlCommand> action)
    {
        using (SqlConnection con = new SqlConnection(this.ConnectionString))
        using (SqlCommand com = new SqlCommand(name, con))
        {
            con.Open();
            com.CommandType = System.Data.CommandType.StoredProcedure;
    
            if (returnType != null)
            {
                com.Parameters.Add("ReturnValue", returnType.Value).Direction = 
                    ParameterDirection.ReturnValue;
            }
            action(com);
        }
    }
