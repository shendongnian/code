    public void RemoveAt(int index)
    {
        if ((index < 0) || (index >= this._size))
        {
            ThrowHelper.ThrowArgumentOutOfRangeException(ExceptionArgument.index, ExceptionResource.ArgumentOutOfRange_Index);
        }
        this._size--;
        if (index < this._size)
        {
            Array.Copy(this.keys, index + 1, this.keys, index, this._size - index);
            Array.Copy(this.values, index + 1, this.values, index, this._size - index);
        }
        this.keys[this._size] = default(TKey);
        this.values[this._size] = default(TValue);
        this.version++;
    }
