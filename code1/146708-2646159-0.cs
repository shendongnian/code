    public Result<Boolean> CreateLocation(LocationKey key)
    {
        LocationDAO locationDAO = new LocationDAO();
        return WrapMethod(() => locationDAO.CreateLocation(key));
    }
    public Result<Boolean> RemoveLocation(LocationKey key)
    {
        LocationDAO locationDAO = new LocationDAO();
        return WrapMethod(() =>  locationDAO.RemoveLocation(key));
    }
    static Result<T> WrapMethod<T>(Func<Result<T>> func)
    {
        try
        {
            return func();
        }
        catch (UpdateException ue)
        {
            return new Result<T>(default(T), ue.Errors);
        }
    }
