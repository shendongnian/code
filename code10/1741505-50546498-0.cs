    public new void Push(State item) {
        base.Push(item);
        OnCollectionChanged(
            new NotifyCollectionChangedEventArgs(NotifyCollectionChangedAction.Add, item, 0));
    }
