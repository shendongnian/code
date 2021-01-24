    OracleConnection CONNECTION 
        = new OracleConnection("Data Source=XX;User Id=XX;Password=XX;");
    CONNECTION.Open();
    OracleCommand cmd = new OracleCommand() { Connection = CONNECTION };
    cmd.CommandText = "GET_CUST_STRING_FROM_DB";
    cmd.CommandType = System.Data.CommandType.StoredProcedure;
    cmd.Parameters.Add("pcustid", OracleType.Double).Value = textBox1.Text;
    cmd.Parameters.Add("return_value", OracleType.VarChar, 500).Direction 
        = System.Data.ParameterDirection.ReturnValue;
    cmd.ExecuteNonQuery();
    var result = cmd.Parameters["return_value"].Value.ToString();
    Console.WriteLine(result);
    CONNECTION.Close();
