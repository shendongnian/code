    Type t = ...;
    if (typeof(IYourInterface).IsAssignableFrom(t) && !t.IsSerializable)
    {
        throw new TypeLoadException(string.Format(
            "The type {0} implements IYourInterface but is not serializable",
            t));
    }
