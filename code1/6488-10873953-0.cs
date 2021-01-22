        public DateTime Start
        {
            get { return _start; }
            set
            {
                if (_end.Equals(DateTime.MinValue))
                {
                    _start = value;
                }
                else if (value.Date < _end.Date)
                {
                    _start = value;
                }
                else
                {
                    throw new ArgumentException("Start date must be before the End date.");
                }
            }
        }
        public DateTime End
        {
            get { return _end; }
            set
            {
                if (_start.Equals(DateTime.MinValue))
                {
                    _end = value;
                }
                else if (value.Date > _start.Date)
                {
                    _end = value;
                }
                else
                {
                    throw new ArgumentException("End date must be after the Start date.");
                }
            }
        }
