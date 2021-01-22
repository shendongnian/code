    List<int> idList = ...;
    using(SqlCommand command = ...)
    {
        ...
        foreach(string idString in ConcatenateValues(ids,",", maxLength, false))
        {
           command.Parameters[...] = idString;
           ... execute command ...
        }
    }
