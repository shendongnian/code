            using (OracleConnection con = new OracleConnection(OracleConnectionHelper.ConnectionStringTransaction))
            {
                using (OracleCommand cmd = con.CreateCommand())
                {
                    if (con.State != ConnectionState.Open)
                    {
                        con.Open();
                    }
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandText = RoutineConstant.Text;
                    cmd.BindByName = true;
                    
                    cmd.ExecuteNonQuery();
                    if (cmd.Parameters["Value"].Value != null && cmd.Parameters["Value"].Value != DBNull.Value)
                    {
                        return Convert.ToDecimal(cmd.Parameters["Value"].Value.ToString());
                    }
                }
             }
