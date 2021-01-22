    public void Add(T item)
    {
        if (this._size == this._items.Length)
        {
            this.EnsureCapacity(this._size + 1);
        }
        this._items[this._size++] = item;
        this._version++;
    }
