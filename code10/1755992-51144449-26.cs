    public BaseModel SomeMethod<T>()
        where T : BaseModel, new
    {
        var model = new T();
        string name = model.Name;
        ...
    }
