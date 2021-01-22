    public static T CreateInstance<T>() where T: new()
    {
        // Do some business logic
        Logger.LogObjectCreation(typeof(T));
        // Actualy instanciate the object
        return new T();
    }
