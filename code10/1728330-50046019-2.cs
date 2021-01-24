        private String _gender = "Male";
        public String gender
        {
            get { return _gender; }
            set
            {
                if (value != _gender)
                {
                    _gender = value;
                    OnPropertyChanged();
                }
            }
        }
