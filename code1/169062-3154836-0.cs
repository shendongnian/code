    class CarListViewModel : INotifyPropertyChanged {
    
        public CarListViewModel() {
            Cars = new ObservableCollectionEx<Car>();
            Cars.CollectionChanged += (sender,e) => OnPropertyChanged("Total");
            Cars.ItemPropertyChanged += (sender,e) => {
                if (e.PropertyName == "Total") {
                    OnPropertyChanged("Total");
                }
            }
        }
    
        public ObservableCollectionEx<Car> Cars {
            get;
            private set;
        }
    
        public decimal Total {
            get {
                return Cars.Sum(x=>x.Total);
            }
        }
    
    }
    class Car : INotifyPropertyChanged {
        public Car() {
            Parts = new ObservableCollectionEx<Part>();
            Parts.CollectionChanged += (sender,e) => OnPropertyChanged("Total");
            Parts.ItemPropertyChanged += (sender,e) => {
                if (e.PropertyName == "Total") {
                    OnPropertyChanged("Total");
                }
            }
        }
        public ObservableCollectionEx<Part> Parts {
            get;
            private set;
        }
        public decimal Total {
            get {
                return Parts.Sum(x=>x.Total);
            }
        }
    }
    class Part : INotifyPropertyChanged {
        private decimal _Total;
        public decimal Total {
            get { return _Total; }
            set {
                _Total = value;
                OnPropertyChanged("Total");
            }
        }
    }
    class ObservableCollectionEx<T> : ObservableCollection<T> 
        where T: INotifyPropertyChanged
    {
        protected override void InsertItem(int index, T item) {
            base.InsertItem(index, item);
            item.PropertyChanged += Item_PropertyChanged;
        }
        protected override void RemoveItem(int index) {
            Items[index].PropertyChanged -= Item_PropertyChanged;
            base.RemoveItem(index);
        }
        protected override void ClearItems() {
            foreach (T item in Items) {
                item.PropertyChanged -= Item_PropertyChanged;
            }
            base.ClearItems();
        }
        protected override void SetItem(int index, T item) {
            T oldItem = Items[index];
            T newItem = item;
            oldItem.PropertyChanged -= Item_PropertyChanged;
            newItem.PropertyChanged += Item_PropertyChanged;
            base.SetItem( index, item );
        }
        private void Item_PropertyChanged(object sender, PropertyChangedEventArgs e) {
            var handler = ItemPropertyChanged;
            if (handler != null) { handler(sender, e); }
        }
        public event PropertyChangedEventHandler ItemPropertyChanged;
    }
