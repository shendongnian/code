    public bool ElementExists(IWebElement e)
    {
        try
        {
            bool b = e.Displayed;
    
            return true;
        }
        catch (Exception)
        {
            return false;
        }
    }
