    public delegate T GetPropertyValueDelegate<T>(IThing t);
    public T GetMaximum<T>(GetPropertyValueDelegate<T> getter)
        where T : IComparable
    {
        if (this.Count == 0) return default(T);
        T max = getter(this[0]);
        for (int i = 1; i < this.Count; i++)
        {
            T ti = getter(this[i]);
            if (max.CompareTo(ti) < 0) max = ti;
        }
        return max;
    }
