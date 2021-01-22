    public virtual Control this[string key]
    {
        get
        {
            if (!string.IsNullOrEmpty(key))
            {
                int index = this.IndexOfKey(key);
                if (this.IsValidIndex(index))
                {
                    return this[index];
                }
            }
            return null;
        }
    }
 
