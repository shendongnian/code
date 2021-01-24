     public DataTable Select(string selectStatment, string parameterName = "", byte[] x = null,string id="Default")
    {
            using (var con = new SqlConnection(ConfigurationManager.ConnectionStrings[id].ConnectionString))
            using (var da = new SqlDataAdapter(selectStatment, con))
            using (var dt = new DataTable())
            {
                if (parameterName != "")
                {
                    da.SelectCommand.Parameters.Add(parameterName, SqlDbType.VarBinary).Value = x;
                }
                da.Fill(dt);
                return dt;
            }
          
    }
