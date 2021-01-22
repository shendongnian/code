        public CalendarBlackoutDatesCollection BlackoutDates
        {
            get
            {
                return _blackoutDates;
            }
            set
            {
                _blackoutDates = value;
                this.RaisePropertyChanged(p => p.BlackoutDates);
            }
        }
