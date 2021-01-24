    public static T GetDatabaseServiceFromConfig<T>(string databaseId)
    {
        object system = null;
        switch (databaseId)
        {
            case DatabaseIds.<DbName>:
                system = new <DbName>Service(new <DbName>ConfigSettings());
                break;
		    // More cases
            default:
                // System not found
                throw new ArgumentOutOfRangeException(databaseId);
            }
        if (!(system is T))
        {
            throw new NotImplementedException("Database type was found and created but does not implement interface: " + typeof(T));
        }
        // Safe cast
        return (T)system;
    }
