        private static IEnumerable<SqlDataRecord> SendRows(List<Invoice> Invoices)
        {
          SqlMetaData[] _TvpSchema = new SqlMetaData[] {
            new SqlMetaData("InvoiceID", SqlDbType.Int),
            new SqlMetaData("NotePath", SqlDbType.VarChar, 512),
            new SqlMetaData("BatchID", SqlDbType.VarChar, 50)
          };
          SqlDataRecord _DataRecord = new SqlDataRecord(_TvpSchema);
    
          foreach(Invoice _Invoice in Invoices)
          {
            _DataRecord.SetInt32(0, _Invoice.Id);
            _DataRecord.SetString(1, _Invoice.NotePath);
            _DataRecord.SetString(2, _Invoice.BatchId);
            yield return _DataRecord;
          }
        }
