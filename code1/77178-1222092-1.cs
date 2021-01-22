    public T Coerce<T>(string value)
    {
        return (T)(((IConvertible)value).ToType(typeof(T),
           CultureInfo.InvariantCulture));
    }
