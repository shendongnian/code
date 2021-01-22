    public static void RegisterCollectionChanged(this INotifyCollectionChanged collection, NotifyCollectionChangedEventHandler handler)
    {
        collection.CollectionChanged += handler;
    }
    public static void UnregisterCollectionChanged(this INotifyCollectionChanged collection, NotifyCollectionChangedEventHandler handler)
    {
        collection.CollectionChanged -= handler;
    }
