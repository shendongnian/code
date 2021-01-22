    static T DirectCast<T>(object o, Type type) where T : class
    {
        if (!(type.IsInstanceOfType(o)))
        {
            throw new ArgumentException();
        }
        T value = o as T;
        if (value == null && o != null)
        {
            throw new InvalidCastException();
        }
        return value;
    }
