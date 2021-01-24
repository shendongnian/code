    void CallerMethod()
    {
        try
        {
            AA("");
            AA("", "");
        }
        catch (Exception)
        {
            //My only one exception
        }
    }
    
    void AA(string B)
    {
        //Do something
    }
    
    void AA(string B, string C)
    {
        //Do something
    }
