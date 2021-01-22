    static GenericCollection()
    {
        if (!typeof(T).IsSubclassOf(typeof(Delegate)))
        {
            throw new InvalidOperationException(typeof(T).Name + " is not a delegate type");
        }
    }
