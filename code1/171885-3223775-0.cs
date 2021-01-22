    public T this[int index]
    {
        get
        {
            if (index >= this._size)
            {
                ThrowHelper.ThrowArgumentOutOfRangeException();
            }
            return this._items[index];
        }
        // ...
