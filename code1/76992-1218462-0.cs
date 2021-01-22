    public void InsertDateTime(DateTime aoDateTime) {
      using (var oracleConnection = new OracleConnection("<my connection string>")) 
      {
        var oracleCommand = new OracleCommand(
          "INSERT INTO MY_TABLE (MY_DATE_FIELD) VALUES (:pMY_DATE_VALUE)", 
          oracleConnection);
        oracleCommand.Parameters.Add(
          new OracleParameter(":pMY_DATE_VALUE", aoDateTime));
        oracleConnection.Open();
        oracleCommand.ExecuteNonQuery();
      }
    }
