         public static SqlDataReader ExecuteCommonReader(string Query, CommandType type, params IDataParameter[] sqlParams )
        {
            try
            {
                SqlCommand _cmd = new SqlCommand();
                string connString = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
                var _con = new SqlConnection(connString);
               
                _con.Open();
                _cmd.Connection = _con;
                _cmd.CommandType = type;
                _cmd.CommandText = Query;
                if (sqlParams != null)
                {
                    foreach (IDataParameter para in sqlParams)
                    {
                        _cmd.Parameters.AddWithValue(para.ParameterName, para.Value);
                    }
                }
                return _cmd.ExecuteReader(CommandBehavior.CloseConnection);
          
            }
            catch (Exception ex)
            {
             
                return null;
            }
        }
