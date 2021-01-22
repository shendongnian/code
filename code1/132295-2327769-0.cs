    public List<T> FindAll(Predicate<T> match)
    {
        if (match == null)
        {
            ThrowHelper.ThrowArgumentNullException(ExceptionArgument.match);
        }
        List<T> list = new List<T>();
        for (int i = 0; i < this._size; i++)
        {
            if (match(this._items[i]))
            {
                list.Add(this._items[i]);
            }
        }
        return list;
    }
