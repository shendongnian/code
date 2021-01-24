            DateTime _lastUpdate;
            double _value;
            TimeSpan _maxInterval = new TimeSpan(0, 0, 0, 0, 10);
            public double Value
            {
                get
                {
                    return (DateTime.Now - _lastUpdate) <=  _maxInterval ? _value : double.NaN;
                }
                set
                {
                    _lastUpdate = DateTime.Now;
                    _value = value;
                }
            }
