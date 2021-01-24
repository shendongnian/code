    public class ObservableCollection<T>
    {
        // Note: the event is no longer virtual
        public event NotifyCollectionChangedEventHandler CollectionChanged;
        protected virtual void OnCollectionChanged(NotifyCollectionChangedEventArgs e)
        {
            CollectionChanged?.Invoke(this, e);
        }
    }
    public class DerivedObservableCollection<T> : ObservableCollection<T>
    {
        private bool _SuppressNotification;
        // This line is removed:
        // public override event NotifyCollectionChangedEventHandler CollectionChanged;
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
        protected override void OnCollectionChanged(NotifyCollectionChangedEventArgs e)
        {
            if (!_SuppressNotification)
            {
                // This is where you raise the event
                base.OnCollectionChanged(e);
                // the next two lines are also removed, since you've already raised the event
                // and you can't raise it directly from the derived class anyway
                
                //if (CollectionChanged != null)
                //    CollectionChanged.Invoke(this, e);
            }
        }
    }
