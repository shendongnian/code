    class SqrtingDataDecorator : IDataReader
    {
        private readonly IDataReader _decorated;
        private double _input;
        public SqrtingDataDecorator(IDataReader decorated)
        {
             _decorated = decorated;
        }
        public bool Read()
        {
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
        //other IDataReader members just throw NotSupportedExceptions
        //omitted for clarity
    }
