    ///Your connection string should be like           
    string str = Data Source=(DESCRIPTION =(ADDRESS = (PROTOCOL = TCP)(HOST = abc )(PORT = 123))(CONNECT_DATA =(SID = xyz)));User Id=abc_xyz;Password=111;Min Pool Size=10;Connection Lifetime=120;Connection Timeout=600;Incr Pool Size=5; Decr Pool Size=2;validate connection=true;
     
       using (OracleConnection con = new OracleConnection(str))
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
