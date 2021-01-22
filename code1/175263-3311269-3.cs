        OracleConnection _conn = new OracleConnection("" );
        _conn.Open();
        OracleCommand oCmd = new OracleCommand();
        oCmd.CommandText = "Testprocdecimal";
        
        oCmd.CommandType = CommandType.StoredProcedure;
        oCmd.Connection = _conn;
        OracleParameter crs = new OracleParameter();
        crs.OracleDbType  = OracleDbType.RefCursor ;
        crs.Direction = ParameterDirection.Output;
        crs.ParameterName = "crs";
        oCmd.Parameters.Add(crs);
        using (OracleDataReader MyReader = oCmd.ExecuteReader())
        {
            int ColumnCount = MyReader.FieldCount;
            // get the data and add the row
            while (MyReader.Read())
            {
                //MyReader.GetOracleValue(1).ToString()
                Console.WriteLine(string.Format("{0}/{1}", MyReader.GetValue(0),MyReader.GetOracleValue(1).ToString()  ));
                
            }
        }
