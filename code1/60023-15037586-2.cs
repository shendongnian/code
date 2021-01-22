    public void Add(TKey key, TValue value)
    {
        if (key == null)
        {
            ThrowHelper.ThrowArgumentNullException(ExceptionArgument.key);
        }
        int num = Array.BinarySearch<TKey>(this.keys, 0, this._size, key, this.comparer);
        if (num >= 0)
        {
            ThrowHelper.ThrowArgumentException(ExceptionResource.Argument_AddingDuplicate);
        }
        this.Insert(~num, key, value);
    }
