    private double? editPropertyOne;
        public double? EditPropertyOne
        {
            get { return editPropertyOne; }
            set
            {
                editPropertyOne = value;
                OnPropertyChanged();
            }
        }
        private string editPropertyTwo;
        public string EditPropertyTwo
        {
            get { return editPropertyTwo; }
            set
            {
                editPropertyTwo = value;
                OnPropertyChanged();
            }
        }
        private TwoProperties _selectedD;
        public TwoProperties SelectedD
        {
            get { return _selectedD; }
            set
            {
                _selectedD = value; OnPropertyChanged();
                if (_selectedD != null)
                {
                    EditPropertyOne = _selectedD.Property1;
                    EditPropertyTwo = _selectedD.Property2;
                }
            }
        }
