    public class Row
    {
        public Row(IDataReader reader)
        { }
    };
    public class RowEnumerator : IEnumerator<Row>
    {
        public RowEnumerator(IDbConnection connection, string SQL)
        {
            _command = connection.CreateCommand();
            _command.CommandText = SQL;
            _reader = _command.ExecuteReader();
        }
        private readonly IDbCommand _command;
        private readonly IDataReader _reader;
        public Row Current => new Row(_reader);
        object IEnumerator.Current => Current;
        public bool MoveNext() => _reader.Read();
        public void Reset() => throw new NotImplementedException();
        public void Dispose()
        {
            _reader.Dispose();
            _command.Dispose();
        }
    }
    public class RowEnumerable : IEnumerable<Row>
    {
        public RowEnumerable(IDbConnection connection, string SQL)
        {
            _connection = connection;
            _SQL = SQL;
        }
        private readonly IDbConnection _connection;
        private readonly string _SQL;
        public IEnumerator<Row> GetEnumerator() => new RowEnumerator(_connection, _SQL);
        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }
