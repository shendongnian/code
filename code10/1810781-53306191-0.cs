    public bool getUsername(string username)
        {
            OracleConnection connection = getConnection();
            OracleCommand oracleCommand = new OracleCommand("Get_Username", connection);
            oracleCommand.CommandType = CommandType.StoredProcedure;
            oracleCommand.Parameters.Add("p_Username", OracleDbType.Varchar2).Value = username;
            oracleCommand.Parameters.Add("p_ReturningUsername", OracleDbType.Varchar2).Direction = ParameterDirection.Output;
    
            try
            {
                oracleCommand.ExecuteNonQuery();
            }
            catch (OracleException ex)
            {
                MessageBox.Show("Exception Message: " + ex.Message);
                MessageBox.Show("Exception Source: " + ex.Source);
            }
    
    
            string tmp = oracleCommand.Parameters["p_ReturningUsername"].Value.ToString();
            connection.Close();
            return tmp == username;
        }
