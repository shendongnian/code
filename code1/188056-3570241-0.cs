    void InvokeCommand (OracleConnection oracleConnection, string tableCommand) 
    {
         using(OracleCommand oracleCommand = new OracleCommand(tableCommand, oracleConnection)) 
         { 
             oracleCommand.ExecuteNonQuery(); 
         } 
    }
