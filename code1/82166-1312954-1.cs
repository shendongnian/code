    public bool UnreliableTask()
    {
        try
        {
            // Do something
        }
        catch (SqlException ex)
        {
            return (ex.Number == -2 || ex.Number == 1205);
        }
        return false;
    }
