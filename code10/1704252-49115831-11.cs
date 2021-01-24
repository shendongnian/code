    private ObservableCollection<DataGridModel> _dataGridCollection=new ObservableCollection<DataGridModel>()
        {
            new DataGridModel(){FirstProperty = "first item",SecondProperty = "second item"},
            new DataGridModel(){FirstProperty = "first item",SecondProperty = "second item"},
            new DataGridModel(){FirstProperty = "first item",SecondProperty = "second item"}
        };
        public ObservableCollection<DataGridModel> DataGridCollection
        {
            get { return _dataGridCollection; }
            set
            {
                if (Equals(value, _dataGridCollection)) return;
                _dataGridCollection = value;
                OnPropertyChanged();
            }
        }
