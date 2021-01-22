    public bool TryCast<T>(ref T t, object o)
    {
        if (
            o == null
            || !typeof(T).IsAssignableFrom(o.GetType())
            )
            return false;
        t = (T)o;
        return true;
    }
