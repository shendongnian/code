        public Labels Label
        {
            get => _label;
            set
            {
                if(value != null)
                {
                    _label = value;
                    OnPropertyChanged(() => Label);
                }
            }
        }
