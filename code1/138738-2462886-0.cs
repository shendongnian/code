    public static T Choose<T>(int index, params T[] args)
    {
        if (index < 1 || index > args.Length)
        {
            return default(T);
        }
        else
        {
            return args[--index];
        }
    }
    // call it like this
    var day = Choose<int?>(1, 30, 28, 29);  // returns 30
