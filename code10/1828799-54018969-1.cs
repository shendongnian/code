    public class ViewModel: INotifyPropertyChanged
    {
        private String _searchText = "Bay?";
        private String _searchResult = "N/A";
        public ObservableCollection<MyDataObject> Entries { get; set; }
        public string SearchText
        {
            get => _searchText;
            set
            {
                if (value == _searchText) return;
                _searchText = value;
                DoSearchBay();
                OnPropertyChanged();
            }
        }
        private void DoSearchBay()
        {
            var sel = Entries.Select((dm, index) => new { index, dm.Bay}).FirstOrDefault(obj => obj.Bay.Equals(_searchText, StringComparison.OrdinalIgnoreCase)) ;
            if (sel != null)
            {
                SearchResult = "Found in row " + sel.index;
            }
            else
            {
                SearchResult = "N/A";
            }
        }
        public string SearchResult
        {
            get => _searchResult;
            set
            {
                if (value == _searchResult) return;
                _searchResult = value;
                OnPropertyChanged();
            }
        }
        public ViewModel()
        {
            //Create Fake values
            Entries = new ObservableCollection<MyDataObject>();
            Entries.Add(new MyDataObject() {Bay = "Bay1", Am9 = "value1-1", Am10 = "value1-2", Am11 = "value1-3" });
            Entries.Add(new MyDataObject() { Bay = "Bay2", Am9 = "value2-1", Am10 = "value2-2", Am11 = "value2-3" });
            Entries.Add(new MyDataObject() { Bay = "Bay3", Am9 = "value3-1", Am10 = "value1-2", Am11 = "value3-3" });
        }
        // ToDo Implement INotifyPropertyChanged...
    }
