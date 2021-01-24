    class ViewModel : ViewModelBase
    {
        public ObservableCollection<Item> Items { get; } = new ObservableCollection<Item>();
        private Item selectedItem;
        public Item SelectedItem
        {
            get => selectedItem;
            set { selectedItem = value; OnPropertyChanged(); }
        }
    }
