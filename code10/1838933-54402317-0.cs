    object sqlResult = cmd.ExecuteScalar();
    switch (sqlResult)
    {
        case int i when i == -1:
            // TODO ...
            break;
        case int i when i == -2:
            // TODO ...
            break;
        case string s:
            // success, and the value was s
            // TODO...
            break;
        default:
            // I HAVE NO CLUE
            throw new SomeSensibleException(...);
    }
