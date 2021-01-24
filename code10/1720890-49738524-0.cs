    // Only resolves the enumerable, not the contained handlers.
    // This enumerable itself is a singleton, you can reference it forever.
    var collection = container.GetInstances<IEventHandler<OrderConfirmed>>();
    // Calls back into the container to get the first element, but nothing more
    var first = collection.First();
    // Since the stream that Simple Injector returns is a IList<T>, getting the last
    // element is an O(1) operation, meaning that only the last element is resolved;
    // not the complete collection.
    var last = collection.Last();
    // Calling .ToArray(), however, will obviously resolve all registrations that are 
    // part of the collection.
    var all = collection.ToArray();
    // Even other collection types such as IReadOnlyCollection<T> behave as streams
    var col = container.GetInstance<IReadOnlyCollection<IEventHandler<OrderConfirmed>>();
    // This gives you the possibility to get a particular item by its index.
    var indexedItem = col[3];
