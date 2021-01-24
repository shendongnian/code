    private Action _unsubscribeHandler;
    public void AttachTo<T, U>(T list) where T : INotifyCollectionChanged, ICollection<U>
    {
        NotifyCollectionChangedEventHandler handler = delegate (object sender, NotifyCollectionChangedEventArgs e)
        {
            UpdateLayout(list.Count);
        };
        list.CollectionChanged += handler;
        _unsubscribeHandler = () => {
            list.CollectionChanged -= handler;     
        };
    }
    protected override void Dispose(bool disposing)
    {
        if (disposing)
        {
            _unsubscribeHandler?.Invoke();
        }
        base.Dispose(disposing);
    }
