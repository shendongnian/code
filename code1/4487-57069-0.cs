    public class MyObservableCollection<T> : ObservableCollection<T>
    {
        // matching constructors ...
        bool isInAddRange = false;
        protected override void OnCollectionChanged(NotifyCollectionChangedEventArgs e)
        {
            // intercept this when it gets called inside the AddRange method.
            if (!isInAddRange) 
                base.OnCollectionChanged(e);
        }
        public void AddRange(IEnumerable<T> items)
        {
             isInAddRange = true;
             foreach (T item in items)
                Add(item);
             isInAddRange = false;
             var e = new NotifyCollectionChangedEventArgs(
                 NotifyCollectionChangedAction.Add,
                 items.ToList());
             base.OnCollectionChanged(e);
        }
    }
