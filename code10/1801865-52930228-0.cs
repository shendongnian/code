    public class Row
    {
        public Cell[] Cells { get; set; }
    }
    public class Cell : INotifyPropertyChanged
    {
        private bool _isChecked;
        public bool IsChecked
        {
            get { return _isChecked; }
            set { _isChecked = value; NotifyPropertyChanged(); }
        }
        public event PropertyChangedEventHandler PropertyChanged;
        private void NotifyPropertyChanged([CallerMemberName] String propertyName = "") =>
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
    public class ViewModel
    {
        public ViewModel()
        {
            const int n = 10;
            const int m = 5;
            List<Row> rows = new List<Row>();
            for (int i = 0; i < n; ++i)
            {
                rows.Add(new Row { Cells = new Cell[m] });
                for (int j = 0; j < m; ++j)
                {
                    rows[i].Cells[j] = new Cell();
                }
            }
            Rows = rows;
        }
        public IEnumerable<Row> Rows { get; set; }
    }
