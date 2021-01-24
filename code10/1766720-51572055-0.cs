     public class ViewModel : INotifyPropertyChanged
    {
        private string _selectedItem;        
        public event PropertyChangedEventHandler PropertyChanged;
        public string SelectedItem
        {
            get { return _selectedItem; }
            set { _selectedItem = value; OnPropertyChanged(); CheckAndInsertIfValid(); }
        }
        public ObservableCollection<string> ItemsSource { get; set; }
        public ViewModel()
        {
            ItemsSource = new ObservableCollection<string>()
            {
                "0", "1", "2", "3", "4" ,"5"
            };
            SelectedItem = ItemsSource[3];
        }
        public virtual void OnPropertyChanged([CallerMemberName]string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        private void CheckAndInsertIfValid()
        {
            if (SelectedItem != "Some Values" && !ItemsSource.Contains(SelectedItem))
                ItemsSource.Add(SelectedItem);
        }
    }
