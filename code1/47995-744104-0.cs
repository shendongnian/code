    public void ForEach(Action<T> action)
    {
        if (action == null)
        {
            ThrowHelper.ThrowArgumentNullException(ExceptionArgument.match);
        }
        for (int i = 0; i < this._size; i++)
        {
            action(this._items[i]);
        }
    }
 
