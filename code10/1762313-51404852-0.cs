    public class ListItem
    {
        public IEnumerable<string> ComboBoxItems { get; set; }
    }
    public class ViewModel
    {
        public ObservableCollection<ListItem> ListItems { get; } 
            = new ObservableCollection<ListItem>();
    }
