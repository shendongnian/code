       var oracleArray = new MyArrayStorageClass
          {
             Array = new string[] {"Hello", "World"}
          };
       command.CommandType = CommandType.StoredProcedure;
       var param = new OracleParameter("ip_parameterName", OracleDbType.Array)
          {
             // Case sensitive match to the `OracleCustomTypeMapping` on the factory
             UdtTypeName = "SCHEMA.UDT_TYPE", 
             Value = oracleArray,
             Direction = ParameterDirection.Input,
          };
       command.Parameters.Add(param);
