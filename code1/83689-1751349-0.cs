    internal static void InsertTableEntries()
    {
        s_table.Add(typeof(byte), OracleDbType.Byte);
        s_table.Add(typeof(byte[]), OracleDbType.Raw);
        s_table.Add(typeof(char), OracleDbType.Varchar2);
        s_table.Add(typeof(char[]), OracleDbType.Varchar2);
        s_table.Add(typeof(DateTime), OracleDbType.TimeStamp);
        s_table.Add(typeof(short), OracleDbType.Int16);
        s_table.Add(typeof(int), OracleDbType.Int32);
        s_table.Add(typeof(long), OracleDbType.Int64);
        s_table.Add(typeof(float), OracleDbType.Single);
        s_table.Add(typeof(double), OracleDbType.Double);
        s_table.Add(typeof(decimal), OracleDbType.Decimal);
        s_table.Add(typeof(string), OracleDbType.Varchar2);
        s_table.Add(typeof(TimeSpan), OracleDbType.IntervalDS);
        s_table.Add(typeof(OracleBFile), OracleDbType.BFile);
        s_table.Add(typeof(OracleBinary), OracleDbType.Raw);
        s_table.Add(typeof(OracleBlob), OracleDbType.Blob);
        s_table.Add(typeof(OracleClob), OracleDbType.Clob);
        s_table.Add(typeof(OracleDate), OracleDbType.Date);
        s_table.Add(typeof(OracleDecimal), OracleDbType.Decimal);
        s_table.Add(typeof(OracleIntervalDS), OracleDbType.IntervalDS);
        s_table.Add(typeof(OracleIntervalYM), OracleDbType.IntervalYM);
        s_table.Add(typeof(OracleRefCursor), OracleDbType.RefCursor);
        s_table.Add(typeof(OracleString), OracleDbType.Varchar2);
        s_table.Add(typeof(OracleTimeStamp), OracleDbType.TimeStamp);
        s_table.Add(typeof(OracleTimeStampLTZ), OracleDbType.TimeStampLTZ);
        s_table.Add(typeof(OracleTimeStampTZ), OracleDbType.TimeStampTZ);
        s_table.Add(typeof(OracleXmlType), OracleDbType.XmlType);
        s_table.Add(typeof(OracleRef), OracleDbType.Ref);
    }
