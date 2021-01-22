    public void DoThings(Action<MyObject> action)
    {
        bool success = false;
        try
        {
            action(new MyObject());
            Commit();
            success = true;
        }
        finally
        {
            if (!success)
                Rollback();
        }
    }
