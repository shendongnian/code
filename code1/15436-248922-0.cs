    public Type GetGenericCollectionItemType(Type type)
    {
        if (type.IsGenericType)
        {
            var args = type.GetGenericArguments();
            if (args.Length == 1 &&
                typeof(ICollection<>).MakeGenericType(args).IsAssignableFrom(type))
            {
                return args[0];
            }
        }
        return null;
    }
