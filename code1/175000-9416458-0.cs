    public class BaseObservableCollection<T> : ObservableCollection<T>, INotifyPropertyChanged
    {
        //Flag used to prevent OnCollectionChanged from firing during a bulk operation like Add(IEnumerable<T>) and Clear()
        private bool _SuppressCollectionChanged = false;
        /// Overridden so that we may manually call registered handlers and differentiate between those that do and don't require Action.Reset args.
        public override event NotifyCollectionChangedEventHandler CollectionChanged;
        public BaseObservableCollection() : base(){}
        public BaseObservableCollection(IEnumerable<T> data) : base(data){}
        #region Event Handlers
        protected override void OnCollectionChanged(NotifyCollectionChangedEventArgs e)
        {
            if( !_SuppressCollectionChanged )
            {
                base.OnCollectionChanged(e);
                if( CollectionChanged != null )
                    CollectionChanged.Invoke(this, e);
            }
        }
        //CollectionViews raise an error when they are passed a NotifyCollectionChangedEventArgs that indicates more than
        //one element has been added or removed. They prefer to receive a "Action=Reset" notification, but this is not suitable
        //for applications in code, so we actually check the type we're notifying on and pass a customized event args.
        protected virtual void OnCollectionChangedMultiItem(NotifyCollectionChangedEventArgs e)
        {
            NotifyCollectionChangedEventHandler handlers = this.CollectionChanged;
            if( handlers != null )
                foreach( NotifyCollectionChangedEventHandler handler in handlers.GetInvocationList() )
                    handler(this, !(handler.Target is ICollectionView) ? e : new NotifyCollectionChangedEventArgs(NotifyCollectionChangedAction.Reset));
        }
        #endregion
        #region Extended Collection Methods
        protected override void ClearItems()
        {
            if( this.Count == 0 ) return;
            List<T> removed = new List<T>(this);
            _SuppressCollectionChanged = true;
            base.ClearItems();
            _SuppressCollectionChanged = false;
            OnCollectionChangedMultiItem(new NotifyCollectionChangedEventArgs(NotifyCollectionChangedAction.Remove, removed));
        }
        public void Add(IEnumerable<T> toAdd)
        {
            if( this == toAdd )
                throw new Exception("Invalid operation. This would result in iterating over a collection as it is being modified.");
            _SuppressCollectionChanged = true;
            foreach( T item in toAdd )
                Add(item);
            _SuppressCollectionChanged = false;
            OnCollectionChangedMultiItem(new NotifyCollectionChangedEventArgs(NotifyCollectionChangedAction.Add, new List<T>(toAdd)));
        }
        public void Remove(IEnumerable<T> toRemove)
        {
            if( this == toRemove )
                throw new Exception("Invalid operation. This would result in iterating over a collection as it is being modified.");
            _SuppressCollectionChanged = true;
            foreach( T item in toRemove )
                Remove(item);
            _SuppressCollectionChanged = false;
            OnCollectionChangedMultiItem(new NotifyCollectionChangedEventArgs(NotifyCollectionChangedAction.Remove, new List<T>(toRemove)));
        }
        #endregion
    }
