    public virtual T Value
    {
        get { return _Value; }
        set
        {
            Type t = typeof(T);
            if (t.IsValueType)
            {
                if (t.IsGenericType
                    && (t.GetGenericTypeDefinition() == typeof(Nullable<>)))
                {
                    Type u = Nullable.GetUnderlyingType(t);
                    if ((u != typeof(long)) && (u != typeof(decimal)))
                    {
                        throw new ArgumentException(
                            "Only long? and decimal? permitted!");
                    }
                }
                else
                {
                    throw new ArgumentException("Only nullable types permitted!");
                }
            }
            if ((value == null) && Required)
            {
                throw new ArgumentException("Required values cannot be null!");
            }
            _Value = value;
        }
    }
