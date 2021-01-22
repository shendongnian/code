    public IControl<T> GetControl<T>()
    {
        if (typeof(T) == typeof(Boolean))
        {
            return new BoolControl(); // Will not compile.
        }
        else if (typeof(T) == typeof(String))
        {
            return new StringControl(); // Will not compile.
        }
        else
        {
            return null;
        }
    }
