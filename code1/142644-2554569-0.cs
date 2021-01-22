    public Result<Boolean> RemoveLocation(LocationKey key)
    {
        return WrapMethod(() => locationDAO.RemoveLocation(key));
    }
    static Result<T> WrapMethod<T>(Func<T> func) {
        try
        {
            return new Result<T>(func());
        }
        catch (SomeExceptionBase ex)
        {
            return new Result<T>(ex.ErrorList);
        }
        catch (Exception ex)
        {
            return new Result<T>((List<Error>)null);
        }
    }
