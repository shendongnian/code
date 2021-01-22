    IDbCommand command = new OracleCommand(); 
    command.CommandText = "Select count(*) from sometable where name = :SomeValue";
    command.CommandType = CommandType.Text;
    OracleParameter parameterSomeValue = new OracleParameter("SomeValue", OracleType.VarChar, 40);
    parameterSomeValue .Direction = ParameterDirection.Input;
    parameterSomeValue .Value = "TheValueToLookFor";
    command.Parameters.Add(parameterSomeValue );
    command.Connection = myconnectionObject;
    int theCount = (int)command.ExecuteScalar();
