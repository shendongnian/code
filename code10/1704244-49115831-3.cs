            private DataGridColumnsModel _dataGridColumnsModel=new DataGridColumnsModel();
        public DataGridColumnsModel DataGridColumnsModel
        {
            get { return _dataGridColumnsModel; }
            set
            {
                if (Equals(value, _dataGridColumnsModel)) return;
                _dataGridColumnsModel = value;
                OnPropertyChanged();
            }
        }
