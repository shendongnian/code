    public int Capacity
    {
        get
        {
            return this._items.Length;
        }
        set
        {
            if (value != this._items.Length)
            {
                if (value < this._size)
                {
                    ThrowHelper.ThrowArgumentOutOfRangeException(ExceptionArgument.value, ExceptionResource.ArgumentOutOfRange_SmallCapacity);
                }
                if (value > 0)
                {
                    T[] destinationArray = new T[value];
                    if (this._size > 0)
                    {
                        Array.Copy(this._items, 0, destinationArray, 0, this._size);
                    }
                    this._items = destinationArray;
                }
                else
                {
                    this._items = List<T>._emptyArray;
                }
            }
        }
    }
 
