    public class ObservableRangeCollection<T> : ObservableCollection<T>
    {
        private bool suppressNotification;
        public ObservableRangeCollection() { }
        public ObservableRangeCollection(IEnumerable<T> items)
            : base(items)
        {
        }
        public override event NotifyCollectionChangedEventHandler CollectionChanged;
        protected virtual void OnCollectionChangedMultiItem(
            NotifyCollectionChangedEventArgs e)
        {
            var handlers = CollectionChanged;
            if (handlers == null) return;
            foreach (NotifyCollectionChangedEventHandler handler in handlers.GetInvocationList())
            {
                if (handler.Target is ReadOnlyObservableCollection<T>
                    && !(handler.Target is ReadOnlyObservableRangeCollection<T>))
                {
                    throw new NotSupportedException(
                        "ObservableRangeCollection is wrapped in ReadOnlyObservableCollection which might be bound to ItemsControl " +
                        "which is internally using ListCollectionView which does not support range actions.\n" +
                        "Instead of ReadOnlyObservableCollection, use ReadOnlyObservableRangeCollection");
                }
                var collectionView = handler.Target as ICollectionView;
                if (collectionView != null)
                {
                    collectionView.Refresh();
                }
                else
                {
                    handler(this, e);
                }
            }
        }
        protected override void OnCollectionChanged(NotifyCollectionChangedEventArgs e)
        {
            if (suppressNotification) return;
            base.OnCollectionChanged(e);
            if (CollectionChanged != null)
            {
                CollectionChanged.Invoke(this, e);
            }
        }
        public void AddRange(IEnumerable<T> items)
        {
            if (items == null) return;
            suppressNotification = true;
            var itemList = items.ToList();
            foreach (var item in itemList)
            {
                Add(item);
            }
            suppressNotification = false;
            if (itemList.Any())
            {
                OnCollectionChangedMultiItem(new NotifyCollectionChangedEventArgs(NotifyCollectionChangedAction.Add, itemList));
            }
        }
        public void AddRange(params T[] items)
        {
            AddRange((IEnumerable<T>)items);
        }
        public void ReplaceWithRange(IEnumerable<T> items)
        {
            Items.Clear();
            OnCollectionChanged(new NotifyCollectionChangedEventArgs(NotifyCollectionChangedAction.Reset));
            AddRange(items);
        }
        public void RemoveRange(IEnumerable<T> items)
        {
            suppressNotification = true;
            var removableItems = items.Where(x => Items.Contains(x)).ToList();
            
            foreach (var item in removableItems)
            {
                Remove(item);
            }
            
            suppressNotification = false;
            if (removableItems.Any())
            {
                OnCollectionChangedMultiItem(new NotifyCollectionChangedEventArgs(NotifyCollectionChangedAction.Remove, removableItems));
            }
        }
    }
    public class ReadOnlyObservableRangeCollection<T> : ReadOnlyObservableCollection<T>
    {
        public ReadOnlyObservableRangeCollection(ObservableCollection<T> list)
            : base(list)
        {            
        }
        protected override event NotifyCollectionChangedEventHandler CollectionChanged;
        protected override void OnCollectionChanged(NotifyCollectionChangedEventArgs e)
        {
            var handlers = CollectionChanged;
            if (handlers == null) return;
            foreach (NotifyCollectionChangedEventHandler handler in handlers.GetInvocationList())
            {
                var collectionView = handler.Target as ICollectionView;
                if (collectionView != null)
                {
                    collectionView.Refresh();
                }
                else
                {
                    handler(this, e);
                }
            }
        }
    }
