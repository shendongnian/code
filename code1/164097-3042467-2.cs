    public class RangeObservableCollection<T> : ObservableCollection<T>
    {
        private bool surpressEvents = false;
        public void AddRange(IEnumerable<T> items)
        {
            surpressEvents = true;
            foreach (var item in items)
            {
                base.Add(item);
            }
            this.surpressEvents = false;
            this.OnCollectionChanged(new NotifyCollectionChangedEventArgs(NotifyCollectionChangedAction.Add, items.ToList()));
        }
        protected override void OnCollectionChanged(System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
            if (!this.surpressEvents)
            {
                base.OnCollectionChanged(e);
            }
        }
    }
