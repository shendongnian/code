        public class DataGridViewModel : INotifyPropertyChanged
    {
        private readonly DataGridModel _dataGridModel = new DataGridModel();
        public DataTable DatatableMerger => _dataGridModel.DatatableMerger;
        public ICommand AddRowsButtonClickCommand => new DelegateCommand(o => ReturnDataTableForGridView());
        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged(string propertyName) => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        public void ReturnDataTableForGridView()
        {
            var dt = new DataTable();
            dt.Columns.Add("Foo");
            dt.Columns.Add("Bar");
            dt.Columns.Add("Baz");
            for (var i = 0; i < 5; i++)
                dt.Rows.Add($"Value {i}", i, DateTime.Now.AddSeconds(i));
            _dataGridModel.DatatableMerger = dt;
            OnPropertyChanged(nameof(DatatableMerger));
        }
    }
