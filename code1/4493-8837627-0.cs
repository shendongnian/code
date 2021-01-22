    public class DeferableObservableCollection<T> : ObservableCollection<T>
    {
        private int deferLevel;
        private class DeferHelper<T> : IDisposable
        {
            private DeferableObservableCollection<T> owningCollection;
            public DeferHelper(DeferableObservableCollection<T> owningCollection)
            {
                this.owningCollection = owningCollection;
            }
            public void Dispose()
            {
                owningCollection.EndDefer();
            }
        }
        private void EndDefer()
        {
            if (--deferLevel <= 0)
            {
                deferLevel = 0;
                OnCollectionChanged(new NotifyCollectionChangedEventArgs(NotifyCollectionChangedAction.Reset));
            }
        }
        public IDisposable DeferNotifications()
        {
            deferLevel++;
            return new DeferHelper<T>(this);
        }
        protected override void OnCollectionChanged(NotifyCollectionChangedEventArgs e)
        {
            if (deferLevel == 0) // Not in a defer just send events as normally
            {
                base.OnCollectionChanged(e);
            } // Else notify on EndDefer
        }
    }
