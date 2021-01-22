    ...
    else if (String.IsNullOrEmpty(value))
    {
        try{
            throw new Exception("name couldn't be null");
        }
        catch(Exception ex)
        {
             //Set Breakpoint Below
             int x=0;
        }
    }
    ...
