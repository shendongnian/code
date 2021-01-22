    try
    {
        using(...)
        {
            try
            {
                // Do stuff
            }
            catch(NonDisposeException e)
            {
            }
        }
    }
    catch(DisposeException e)
    {
    }
