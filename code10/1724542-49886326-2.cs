    public class MainViewModel : ViewModelBase
    {
        public MainViewModel()
        {
            //  TODO:
            //      Load CSV
            //  TODO: 
            //      These are fake. Get actual column names from CSV
            ColumnNames = new List<string> { "Foo", "Bar", "Numeric" };
            Columns = new List<ColumnHeaderViewModel>();
            foreach (var name in ColumnNames)
            {
                Data.Columns.Add(new DataColumn(name));
                var col = new ColumnHeaderViewModel(ColumnNames, name);
                col.NameChanging += Column_NameChanging;
                Columns.Add(col);
            }
            UpdateDataTableFromCSVRows();
        }
        private void Column_NameChanging(object sender, ValueChangingEventArgs<String> e)
        {
            var col = sender as ColumnHeaderViewModel;
            //  Swap names. DataTable throws an exception on column name collisions
            var otherCol = Columns.FirstOrDefault(c => c != col && c.ColumnName == e.NewValue);
            if (e.OldValue != null && otherCol != null)
            {
                otherCol.Rename(e.OldValue);
            }
            UpdateDataTableFromCSVRows();
        }
        protected void UpdateDataTableFromCSVRows()
        {
            //  TODO:
            //      Update the DataTable from the CSV rows, based on the new 
            //      column names. 
        }
        public List<ColumnHeaderViewModel> Columns { get; private set; }
        public List<String> ColumnNames { get; private set; }
        private DataTable _data = default(DataTable);
        public DataTable Data
        {
            get { return _data; }
            private set
            {
                if (value != _data)
                {
                    _data = value;
                    OnPropertyChanged();
                }
            }
        }
    }
