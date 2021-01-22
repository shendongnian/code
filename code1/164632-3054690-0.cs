    public TResult ExecFunc<T1, T2, T3, TResult>(Func<T1, T2, T3, TResult> function, T1 t1Param, T2 t2Param, T3 t3Param)
    {
        try
        {
            return function(t1Param, t2Param, t3Param);
        }
        catch (Exception exception)
        {
            throw new Exception(exception.Message);
        }
    }
