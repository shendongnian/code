    /// <summary>
    ///     This API supports the Entity Framework Core infrastructure and is not intended to be used
    ///     directly from your code. This API may change or be removed in future releases.
    /// </summary>
    object IDbSetCache.GetOrAddSet(IDbSetSource source, Type type)
    {
        CheckDisposed();
    
        if (!_sets.TryGetValue(type, out var set))
        {
            set = source.Create(this, type);
            _sets[type] = set;
        }
    
        return set;
    }
