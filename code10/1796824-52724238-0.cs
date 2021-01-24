    class DataGridViewModel : ObservableObject
    {
        public ObservableCollection<LineViewModel> TableDat { get; private set; }
        public DataGridViewModel()
        {
            TableDat = new ObservableCollection<LineViewModel>()
            {
                new LineViewModel(1,2,888,6,5),
                new LineViewModel(122,2,888,6,5),
            };
        }
    }
