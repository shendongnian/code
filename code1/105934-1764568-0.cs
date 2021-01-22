        try
        {
            using (SqlConnection sqlConn = new SqlConnection("Context Connection=true"))
            {
                sqlConn.Open();
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.CommandText = "uspApp_GetLookup";
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Connection = sqlConn;
                    cmd.Parameters.AddWithValue("ID_Lookup", ID_Lookup);
                    SqlParameter parameter = new SqlParameter("OutputValue", null);
                    parameter.DbType = DbType.Int32;
                    parameter.Direction = ParameterDirection.Output;
                    cmd.Parameters.Add(parameter);
                    cmd.ExecuteNonQuery();
                    if (cmd.Parameters != null && cmd.Parameters["ID_OutputValue_Account"] != null)
                    {
                        return int.Parse(cmd.Parameters["OutputValue"].Value.ToString());
                    }
                    return -1;
                }
            }
        }
        catch
        {
            throw;
        }
    }
