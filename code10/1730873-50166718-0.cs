     string CommandStr = "BFN_HASH_PASSWORD";
    
                using (OracleConnection conn = new OracleConnection(oradb))
                        using (OracleCommand cmd = new OracleCommand(CommandStr, conn))
                        {
                            cmd.CommandType = CommandType.StoredProcedure;
                            cmd.BindByName = true;
    
                            cmd.Parameters.Add("V_INPASSWD",OracleDbType.Varchar2,ParameterDirection.Input);
                            cmd.Parameters["V_INPASSWD"].Value = "test";
                            cmd.Parameters["V_INPASSWD"].Size = 1000;
    
                            cmd.Parameters.Add("V_OUTPASSWD", OracleDbType.Varchar2,ParameterDirection.ReturnValue);
                            cmd.Parameters["V_OUTPASSWD"].Size = 1000;
    
                            conn.Open();
    
                            cmd.ExecuteNonQuery();
                            string output = (string)cmd.Parameters["V_OUTPASSWD"].Value.ToString();
    
                           MessageBox.Show("hash pass:"+ output);
                           MessageBox.Show("hash pass:" + cmd.Parameters["V_INPASSWD"].Value.ToString());
                        }
