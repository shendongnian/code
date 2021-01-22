    public class ViewModel : INotifyPropertyChanged
    {
        private Item _selectedItem;
        public ViewModel()
        {
            Items = new ObservableCollection<Item>()
                {
                    new Item {Name = "Foo"},
                    new Item {Name = "Bar"}
                };
            foreach ( Item anItem in Items )
            {
                anItem.PropertyChanged += OnItemIsSelectedChanged;
            }
        }
        public ObservableCollection<Item> Items { get; private set; }
        public Item SelectedItem
        {
            get { return _selectedItem; }
            set
            {
                // only update if the value is difference, don't
                // want to send false positives
                if ( _selectedItem == value )
                {
                    return;
                }
                _selectedItem = value;
                OnPropertyChanged("SelectedItem");
            }
        }
        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnItemIsSelectedChanged(object sender, PropertyChangedEventArgs e)
        {
            if ( e.PropertyName != "IsSelected" )
            {
                return;
            }
            SelectedItem = sender as Item;
        }
        private void OnPropertyChanged(string propertyName)
        {
            if ( PropertyChanged != null )
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }
