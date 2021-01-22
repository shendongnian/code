    public static T Create(string loadCode, Func<string,T> construct)
    {
        T item = construct(loadCode);
        if (!item.IsEmpty())
        {
            return item;
        }
        else
        {
            throw new CannotInstantiateException();
        }
    }
