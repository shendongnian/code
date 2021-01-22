    public DataTable ReturnSomething()
    {
        DataTable returnValue = null;
        try
        {
            //logic here
            returnValue = ds.Tables[0]; 
        }
        catch (Exception e)
        {
            ErrorString=e.Message;
        }
        return returnValue;
    }
