    public void WithAssignment<T>(ref T var, T val, Action action)
    {
        T original = var;
        var = val;
        try
        {
            action();
        }
        finally
        {
            var = original;
        }
    }
