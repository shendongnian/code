    public virtual object Peek()
    {
        if (this._size == 0)
        {
            throw new InvalidOperationException(Environment.GetResourceString("InvalidOperation_EmptyQueue"));
        }
        return this._array[this._head];
    }
 
