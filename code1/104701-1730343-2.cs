    List<int> idList = ...;
    using(SqlCommand command = ...)
    {
        ...
        foreach(string idString in ConcatenateValues(ids,",", maxLength, false))
        {
           command.Parameters[...] = idString;
           // or command.CommandText = "SELECT ... IN (" + idString + ")...";
           ... execute command ...
        }
    }
