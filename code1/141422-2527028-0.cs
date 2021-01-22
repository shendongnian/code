    void trySomething(Action mightThrow)
    {
        try
        {
            mightThrow();
        }
        catch(SqlException)
        {
        }
        catch(InvalidOperationException)
        {
        }
    }
