    class SqrtingDataDecorator : IDataReader
    {
        private readonly IDataReader _decorated;
        private double _input;
        public SqrtingDataDecorator(IDataReader decorated)
        {
             _decorated = decorated;
        }
        public bool Read() {
            while (_decorated.Read())
            {
                _input = _decorated.GetDouble(0);
                if (_input >= 0)
                    return true;
            }
            return false;
        }
        public object GetValue(int index)
        {
            return Math.Sqrt(_input);
        }
        public int FieldCount { get { return 1; } }
    }
    IDataReader dr = ///.ExecuteDataReader("select floatCol from A", or whatever
    using (SqlTransaction tx = _connection.BeginTransaction())
    {
        try
        {
            using (SqlBulkCopy sqlBulkCopy =
                new SqlBulkCopy(_connection, SqlBulkCopyOptions.Default, tx))
                {
                    sqlBulkCopy.DestinationTableName = "B";
                    SetColumnMappings(sqlBulkCopy.ColumnMappings);
                    var sqrter = new SqrtingDataDecorator(dr);
                    sqlBulkCopy.WriteToServer(sqrter);
                    tx.Commit();
                }
        }
        catch
        {
            tx.Rollback();
            throw;
        }
    }
