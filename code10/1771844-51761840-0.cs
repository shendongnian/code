    private IEnumerable<SqlDataRecord> CreateSqlRecord(IEnumerable<DataElementInput> entities)
    {
        SqlMetaData[] metaData = new SqlMetaData[4];
        metaData[0] = new SqlMetaData("A", SqlDbType.Int);
        metaData[1] = new SqlMetaData("B", SqlDbType.DateTime);
        metaData[2] = new SqlMetaData("C", SqlDbType.DateTime);
        metaData[3] = new SqlMetaData("Value", SqlDbType.Decimal, 19, 6);
        SqlDataRecord record = new SqlDataRecord(metaData);
        foreach (Model myModel in entities)
        {
            record.SetInt32(0, myModel .A);
            record.SetDateTime(1,myModel.B);
            record.SetDateTime(2, myModel.C);
            record.SetDecimal(3, (Decimal)myModel.Value);
            yield return record;
        }
    }
