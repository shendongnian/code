    comm = new OracleCommand();
    comm.CommandType = CommandType.StoredProcedure;
    comm.Connection = conn;
    comm.CommandText = "log_in";
    comm.Parameters.Add("x", OracleDbType.Varchar2, ParameterDirection.Input).Value = textBox1.Text; 
       // As far as I remember "ParameterDirection.Input" is the default, so you may skip it
    comm.Parameters.Add("y", OracleDbType.Varchar2, ParameterDirection.Input).Value = textBox2.Text;
    comm.Parameters.Add("ret", OracleDbType.Byte, ParameterDirection.ReturnValue);
    comm.Parameters["ret"].DbType = DbType.Byte;
    comm.ExecuteNonQuery();
    String returnValue = comm.Parameters["ret"].Value.ToString();
