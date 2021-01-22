    class Invoice
    {
      public int Id { get; set; }
      public string NotePath { get; set; }
      public int BatchId { get; set; }
    }
    
    class InvoiceCollection : List<Invoice>, IEnumerable<SqlDataRecord>
    {
      IEnumerator<SqlDataRecord> IEnumerable<SqlDataRecord>.GetEnumerator()
      {
        SqlDataRecord r - new SqlDataRecord(
          new SqlMetaData("InvoiceId", SqlDataType.Int), 
          new SqlMetaData("NotePath", SqlDataType.VarChar), 
          new SqlMetaData("BatchId", SqlDataType.Int)
        );
    
        foreach(var item in this)
        {
          r.SetInt32(0, item.Id);
          r.SetString(1, item.NotePath);
          r.SetInt32(2, item.BatchId);
          yield return r;
        }
    }
