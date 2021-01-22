    public SortedList(IDictionary<TKey, TValue> dictionary, IComparer<TKey> comparer) : this((dictionary != null) ? dictionary.Count : 0, comparer)
    {
        if (dictionary == null)
        {
            ThrowHelper.ThrowArgumentNullException(ExceptionArgument.dictionary);
        }
        dictionary.Keys.CopyTo(this.keys, 0);
        dictionary.Values.CopyTo(this.values, 0);
        Array.Sort<TKey, TValue>(this.keys, this.values, comparer);
        this._size = dictionary.Count;
    }
