    public bool AssertThrows<TException>(
        Action action,
        Func<TException, bool> exceptionCondition = null)
        where TException : Exception 
    {
        try
        {
            action();
        }
        catch (TException ex)
        {
            if (exceptionCondition != null)
            {
                return exceptionCondition(ex);
            }
        
            return true;
        }
        catch
        {
            return false;
        }
        
        return false; 
    }
