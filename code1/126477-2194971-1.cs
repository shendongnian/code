    public static object CreateInstance(Type type)
    {
        // Do some business logic
        Logger.LogObjectCreation(type);
        // Actualy instanciate the object
        return Activator.CreateInstance(type);
    }
