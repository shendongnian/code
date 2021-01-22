    public class RangeObservableCollection<T> : ObservableCollection<T>
    {
        private bool _SuppressNotification;
        public override event NotifyCollectionChangedEventHandler CollectionChanged;
        protected virtual void OnCollectionChangedMultiItem(
            NotifyCollectionChangedEventArgs e)
        {
            NotifyCollectionChangedEventHandler handlers = this.CollectionChanged;
            if (handlers != null)
            {
                foreach (NotifyCollectionChangedEventHandler handler in 
                    handlers.GetInvocationList())
                {
                    if (handler.Target is CollectionView)
                        ((CollectionView)handler.Target).Refresh();
                    else
                        handler(this, e);
                }
            }
        }
        protected override void OnCollectionChanged(
            NotifyCollectionChangedEventArgs e)
        {
            if (!_SuppressNotification)
                base.OnCollectionChanged(e);
        }
        public void AddRange(IEnumerable<T> list)
        {
            if (list == null)
                throw new ArgumentNullException("list");
            _SuppressNotification = true;
            foreach (T item in list)
            {
                Add(item);
            }
            _SuppressNotification = false;
            OnCollectionChangedMultiItem(new NotifyCollectionChangedEventArgs(NotifyCollectionChangedAction.Add, list));
        }
    }
