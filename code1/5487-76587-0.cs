    public void Dispose()
    {
        Exception ex = null;
        try
        {
            sr.Dispose();
        }
        catch (Exception e)
        {
            ex = e;
        }
    
        try
        {
            bs.Dispose();
        }
        catch (Exception e)
        {
            if (ex != null)
            {
                ex.InnerException = e;
            }
            else
            {
                ex = e;
            }
        }
    
        try
        {
            fs.Dispose();
        }
        catch (Exception e)
        {
            if (ex != null)
            {
                if (ex.InnerException != null)
                {
                    ex.InnerException.InnerException = e;
                }
                else
                {
                    ex.InnerException = e;
                }
            }
            else
            {
                ex = e;
            }
        }
        if (ex != null)
        {
            throw ex;
        }
    }
