    public TValue this[TKey key]
    {
        get
        {
            int index = this.FindEntry(key);
            if (index >= 0)
            {
                return this.entries[index].value;
            }
            ThrowHelper.ThrowKeyNotFoundException();
            return default(TValue);
        }
        set
        {
            this.Insert(key, value, false);
        }
    }
