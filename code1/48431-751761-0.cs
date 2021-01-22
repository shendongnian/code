    public void doSomething()
    {
        try
        {
           // actual code goes here
        }
        catch (EspecificException ex)
        {
            HandleException(ex);
        }
        catch (Exception ex)
        {
            throw;
        }
    }
