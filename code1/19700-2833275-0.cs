    private void Test()
    {
      int? iTestA;
      int? iTestB;
      int iTestC;
      string sTestA;
      string sTestB;
      //Create connection
      using (SqlConnection oConnection = new SqlConnection(@""))
      {
        //Open connection
        oConnection.Open();
        //Create command
        using (SqlCommand oCommand = oConnection.CreateCommand())
        {
          //Set command text
          oCommand.CommandText = "SELECT null, 1, null, null, '1'";
          //Create reader
          using (SqlDataReader oReader = oCommand.ExecuteReader())
          {
            //Read the data
            oReader.Read();
            //Set the values
            iTestA = oReader[0] as int?;
            iTestB = oReader[1] as int?;
            iTestC = oReader[2] as int? ?? -1;
            sTestA = oReader[3] as string;
            sTestB = oReader[4] as string;
          }
        }
      }
    }
