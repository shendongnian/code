    public DataTable ExeSQLParamByDateTime(string sprocName, DataTable paramArray, string tableTypeName, int LegacyKey, DateTime startingDate, DateTime endingDate,
            int unitNumberFrom, int unitNumberTo, int BldgSegsFrom, int BldgSegsFromTo, int SquareFootageFrom, int SquareFootageTo, int WoodStoriesFrom,
            int WoodStoriesTo, int StatusKey
            )
    {
        var result = new DataTable();
        //Not good to re-use the same connection object.
        // ADO.Net is designed to use connection pooling, which means you want a new connection each time.
        // Just re-use the connection string
        using (var cn = new SqlConnection(this.dbconn.ConnectionString))
        using (var cmd = new SqlCommand(sprocName, cn))
        {
            cmd.CommandType = CommandType.StoredProcedure; //only need to do this once
            //Most parameters can get down to a single line
            cmd.Parameters.Add(tableTypeName, SqlDbType.Structured).Value = paramArray;
            cmd.Parameters.Add("@LegacyKey", SqlDbType.Int).Value = LegacyKey;
            cmd.Parameters.Add("@StartingDate", SqlDbType.DateTime).Value = startingDate.Date;
            cmd.Parameters.Add("@EndingDate", SqlDbType.DateTime).Value = endingDate.Date;
            cmd.Parameters.Add("@UnitNumberFrom", SqlDbType.Int).Value = unitNumberFrom;
            cmd.Parameters.Add("@UnitNumberTo", SqlDbType.Int).Value = unitNumberTo;
            //etc
            //etc
            //you can also handle parameters with size scopes this way:
            cmd.Parameters.Add("@FakeParam", SqlDbType.Decimal, 5, 2).Value = 123.45;
            cmd.Parameters.Add("@AlsoFake", SqlDbType.NVarChar, 30).Value = "Hello World";
            cn.Open(); // wait as long as possible to open the connection
            using (var rdr = cmd.ExecuteReader())
            {
                result.Load(rdr);
                rdr.Close();
            }
        } //using block handles closing the connection, even if an exception is thrown
        return result;
    }
