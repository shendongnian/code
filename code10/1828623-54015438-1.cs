    Dictionary<Type, Action<object>> dictionary;
    // (initialize and populate somewhere else) ...
    if (dictionary.TryGetValue(element.GetType(), out var action)
    {
        action(element);
    }
