    Delegate printer;
    if (Printers.TryGetValue(typeof(T), out printer))
    {
        ((Action<T>) printer)(t);
    }
    else
    {
        // Error handling
    }
