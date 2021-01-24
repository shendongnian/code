    public class Pallet : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
    
        public Pallet()
        {
            BoxesOnPallet = new ObservableCollection<Box>
            {
                new Box(3),
                new Box(8),
                new Box(5),
                new Box(1),
                new Box(0)
            };
        }
    
        private ObservableCollection<Box> _boxesOnPallet;
        public ObservableCollection<Box> BoxesOnPallet
        {
            get { return _boxesOnPallet; }
            set
            {
                if (_boxesOnPallet != null)
                {
                    foreach (Box box in _boxesOnPallet)
                    {
                        if (box != null)
                            box.PropertyChanged -= Box_PropertyChanged;
                    }
                    _boxesOnPallet.CollectionChanged -= BoxesOnPallet_CollectionChanged;
                }
                _boxesOnPallet = value;
                if (value != null)
                {
                    foreach (Box box in value)
                    {
                        if (box != null)
                            box.PropertyChanged += Box_PropertyChanged;
                    }
                    value.CollectionChanged += BoxesOnPallet_CollectionChanged;
                }
                OnPropertyChanged(nameof(BoxesOnPallet));
            }
        }
    
        private void BoxesOnPallet_CollectionChanged(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
            if (e?.OldItems != null)
            {
                foreach (Box box in e.OldItems)
                {
                    if (box != null)
                        box.PropertyChanged -= Box_PropertyChanged;
                }
            }
            if(e?.NewItems != null)
            {
                foreach (Box box in e.NewItems)
                {
                    if (box != null)
                        box.PropertyChanged += Box_PropertyChanged;
                }
            }
        }
    
        private void Box_PropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            if (e.PropertyName.Equals(nameof(Box.NumberOfPiecesinBox)))
                OnPropertyChanged(nameof(ItemTotal));
        }
    
        public int ItemTotal
        {
            get { return BoxesOnPallet.Sum(x => x.NumberOfPiecesinBox); }
        }
    
        private void OnPropertyChanged(string propertyName)
        {
            var handler = PropertyChanged;
            if (handler != null)
                handler(this, new PropertyChangedEventArgs(propertyName));
        }
    }
