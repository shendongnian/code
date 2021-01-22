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
        //to be continued...
    }        
