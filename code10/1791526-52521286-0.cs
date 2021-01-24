    override public int CommandTimeout { // V1.2.3300, XXXCommand V1.0.5000
        get {
            return _commandTimeout;
        }
        set {
            Bid.Trace("<sc.SqlCommand.set_CommandTimeout|API> %d#, %d\n", ObjectID, value);
            if (value < 0) {
                throw ADP.InvalidCommandTimeout(value);
            }
            if (value != _commandTimeout) {
                PropertyChanging();
                _commandTimeout = value;
            }
        }
    }
