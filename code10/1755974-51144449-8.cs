    public BaseModel SomeMethod<T>(T model)
        where T : BaseModel, new
    {
        var x = new T();
        ...
    }
