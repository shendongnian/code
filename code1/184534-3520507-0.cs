    public class ObservableUIElementCollection : UIElementCollection, INotifyCollectionChanged, INotifyPropertyChanged
    {
        public ObservableUIElementCollection(UIElement visualParent, FrameworkElement logicalParent)
            : base(visualParent, logicalParent)
        {
        }
        public override int Add(UIElement element)
        {
            int index = base.Add(element);
            var args = new NotifyCollectionChangedEventArgs(NotifyCollectionChangedAction.Add, element, index);
            OnCollectionChanged(args);
            OnPropertyChanged("Count");
            OnPropertyChanged("Item[]");
            return index;
        }
        public override void Clear()
        {
            base.Clear();
            OnCollectionChanged(new NotifyCollectionChangedEventArgs(NotifyCollectionChangedAction.Reset));
            OnPropertyChanged("Count");
            OnPropertyChanged("Item[]");
        }
        public override void Insert(int index, UIElement element)
        {
            base.Insert(index, element);
            var args = new NotifyCollectionChangedEventArgs(NotifyCollectionChangedAction.Add, element, index);
            OnCollectionChanged(args);
            OnPropertyChanged("Count");
            OnPropertyChanged("Item[]");
        }
        public override void Remove(UIElement element)
        {
            int index = IndexOf(element);
            if (index >= 0)
            {
                RemoveAt(index);
                var args = new NotifyCollectionChangedEventArgs(NotifyCollectionChangedAction.Remove, element, index);
                OnCollectionChanged(args);
                OnPropertyChanged("Count");
                OnPropertyChanged("Item[]");
            }
        }
        public override UIElement this[int index]
        {
            get
            {
                return base[index];
            }
            set
            {
                base[index] = value;
                var args = new NotifyCollectionChangedEventArgs(NotifyCollectionChangedAction.Replace, value, index);
                OnCollectionChanged(args);
                OnPropertyChanged("Item[]");
            }
        }
        public event NotifyCollectionChangedEventHandler CollectionChanged;
        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnCollectionChanged(NotifyCollectionChangedEventArgs e)
        {
            var handler = CollectionChanged;
            if (handler != null)
                handler(this, e);
        }
        protected virtual void OnPropertyChanged(string propertyName)
        {
            var handler = PropertyChanged;
            if (handler != null)
                handler(this, new PropertyChangedEventArgs(propertyName));
        }
    }
