    public T Find(Predicate<T> match)
    {
        if (match == null)
        {
            ThrowHelper.ThrowArgumentNullException(ExceptionArgument.match);
        }
        for (int i = 0; i < this._size; i++)
        {
            if (match(this._items[i]))
            {
                return this._items[i];
            }
        }
        return default(T);
    }
