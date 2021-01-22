    public static Save<T>(AccessControl.User user,T entity) where T:PersistanceLayerBaseClass
    {
        if(CanWrite(user, entity))
        {
            entity.save();
        }
        else
        {
            throw new Exception("Cannot Save");
        }
    }
