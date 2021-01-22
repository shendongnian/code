    public ObservableCollection<MyItem> MyCollectionOfItems {
        get;
        private set;
    }
    private MyItem selectedItem;
    public MyItem SelectedItem{
        get { return selectedItem; }
        set {
            if (!Object.Equals(selectedItem, value)) {
                selectedItem = value;
                // Ensure you implement System.ComponentModel.INotifyPropertyChanged
                OnNotifyPropertyChanged("SelectedItem");
            }
        }
    }
