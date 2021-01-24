     private ObservableCollection<Model> _dgCollection = new ObservableCollection<Model>()
        {
            new Model(){Checked = true},
            new Model(){Checked = false},
            new Model(){Checked = true},
        };
        public ObservableCollection<Model> DgCollection
        {
            get { return _dgCollection; }
            set
            {
                if (Equals(value, _dgCollection)) return;
                _dgCollection = value;
                OnPropertyChanged();
            }
        }
