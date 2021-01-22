    public Repository(...)
    {
        // code...
        GetByIdAccepted = ExamineIdKey();
    }
    
    protected bool ExamineIdKey()
    {
        // Fetch the type and look for an "Id"-member
        return typeof(TModel).GetMember("Id", BindingFlags.Instance | BindingFlags.Public).Length > 0;
    }
    
    public TModel GetById(object id)
    {
        // Validate that GetById is ok for our given model
        if(!GetByIdAccepted)
            throw new InvalidOperationException("error text");
    
        object model;
        if (Connection.TryGetObjectByKey(new EntityKey(EntityName, "Id", id), out model))
            return (TModel)model;
    
        return null;
    }
