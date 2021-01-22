    public bool IsSet<T>(T value, T flag)
    {
        return (value & flag) == flag;
    }
    
    if (IsSet(letter, Letters.A))
    {
       // ...
    }
    // If you want to check if BOTH Letters.A and Letters.B are set:
    if (IsSet(letter, Letters.A & Letters.B))
    {
       // ...
    }
    // If you want an OR, I'm afraid you will have to be more verbose:
    if (IsSet(letter, Letters.A) || IsSet(letter, Letters.B))
    {
       // ...
    }
