    public int IndexOf(T item)
    {
        return Array.IndexOf<T>(this._items, item, 0, this._size);
    }
    public static int IndexOf<T>(T[] array, T value, int startIndex, int count)
    {
        return EqualityComparer<T>.Default.IndexOf(array, value, startIndex, count);
    }
    internal virtual int IndexOf(T[] array, T value, int startIndex, int count)
    {
        int num = startIndex + count;
        for (int i = startIndex; i < num; i++)
        {
            if (this.Equals(array[i], value))
                return i;
        }
        return -1;
    }
 
 
