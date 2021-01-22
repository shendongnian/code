    public class RangeObservableCollection<T> : ObservableCollection<T>
    {
        private bool supressEvents = false;
        public void AddRange(IEnumerable<T> items)
        {
            supressEvents = true;
            foreach (var item in items)
            {
                base.Add(item);
            }
            this.supressEvents = false;
            this.OnCollectionChanged(new NotifyCollectionChangedEventArgs(NotifyCollectionChangedAction.Add, items.ToList()));
        }
        protected override void OnCollectionChanged(NotifyCollectionChangedEventArgs e)
        {
            if (!this.surpressEvents)
            {
                base.OnCollectionChanged(e);
            }
        }
    }
