        private Dictionary<string, ValuesDataTable> _valuesDataTable;
        public Dictionary<string, ValuesDataTable> ValuesDataTable
        {
            get { return _valuesDataTable; }
            set
            {
                if (Equals(value, _valuesDataTable)) return;
                _valuesDataTable = value;
                OnPropertyChanged();
            }
        }
