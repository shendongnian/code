    public class SomeEvent
    {
        private DateTime _processDate; // map this
        public SomeEvent()
        {
            _processDate = new DateTime(1900, 1, 1);
        }
        public DateTime? ProcessDate
        {
            get
            {
                if (_processDate == new DateTime(1900, 1, 1))
                {
                    return null;
                }
                return _processDate;
            }
            set
            {
                _processDate = value ?? new DateTime(1900, 1, 1);
            }
        }
    }
