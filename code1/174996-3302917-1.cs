    public class RangeObservableCollection<T> : ObservableCollection<T>
    {
        private bool _SuppressNotification;
        protected override void OnCollectionChanged(NotifyCollectionChangedEventArgs e)
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
            OnCollectionChanged(new NotifyCollectionChangedEventArgs(NotifyCollectionChangedAction.Add, list));
        }
    }
