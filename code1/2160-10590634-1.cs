    public static T CreateAndInit<T>() where T : new()
    {
        var t = new T();
        // Some initialization code...
        return t;
    }
