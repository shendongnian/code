      public ObservableCollection<ClassItem> ItemsCollection
            {
                get
                {
                    return _itemsCollection;
                }
                set
                {
                    _itemsCollection= value;
                    NotifyPropertyChanged("ItemsCollection");
                }
            }
