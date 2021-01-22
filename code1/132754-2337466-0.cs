    public virtual bool Contains(object item)
    {
        if (item == null)
        {
            for (int j = 0; j < this._size; j++)
            {
                if (this._items[j] == null)
                {
                    return true;
                }
            }
            return false;
        }
        for (int i = 0; i < this._size; i++)
        {
            if ((this._items[i] != null) && this._items[i].Equals(item))
            {
                return true;
            }
        }
        return false;
    }
