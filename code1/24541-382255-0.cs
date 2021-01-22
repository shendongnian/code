    class Record {
      public int Value1 { get; set; }
      public int Value2 { get; set; }
    }
    Record[] records = GetRecords();
    const string CMD_TEXT = "INSERT INTO TABLE (Col1, Col2) VALUES (:Col1, :Col2);"
    using (var conn = new OracleConnection(connectionString))
    using (var cmd = new OracleCommand(CMD_TEXT, conn)) {
       cmd.BindByName = true;
       // number of rows to insert
       cmd.ArrayBindCount = records.Length;
       // bind array of values to parameters
       cmd.Parameters.Add(":col1", OracleDbType.Int32, 
          records.Select(r => r.Value1).ToArray()
       );
       cmd.Parameters.Add(":col2", OracleDbType.Int32, 
          records.Select(r => r.Value2).ToArray()
       );
       conn.Open();
       cmd.ExecuteNonQuery();
       conn.Close();
    }
