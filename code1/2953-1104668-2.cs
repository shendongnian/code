    private readonly int _finalCount;
    /// <summary>
    /// Takes a count of how many key-value pairs should be allowed.
    /// Dictionary can be modified to add up to that many pairs, but no
    /// pair can be modified or removed after it is added.  Intended to be
    /// used with an object initializer.
    /// </summary>
    /// <param name="count"></param>
    public ReadOnlyDictionary(int count)
    {
        _dict = new SortedDictionary<TKey, TValue>();
        _finalCount = count;
    }
    
    /// <summary>
    /// To allow object initializers, this will allow the dictionary to be
    /// added onto up to a certain number, specifically the count set in
    /// one of the constructors.
    /// </summary>
    /// <param name="key"></param>
    /// <param name="value"></param>
    public void Add(TKey key, TValue value)
    {
        if (_dict.Keys.Count < _finalCount)
        {
            _dict.Add(key, value);
        }
        else
        {
            throw new InvalidOperationException(
                "Cannot add pair <" + key + ", " + value + "> because " +
                "maximum final count " + _finalCount + " has been reached"
            );
        }
    }
