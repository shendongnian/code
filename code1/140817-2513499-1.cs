    _client = GetSocketFromSomewhere();
    {
        Socket temp = _client;
        try 
        { 
            DoStuff();
            Close(); 
        }
        finally
        {
            if (temp != null) ((IDispose)temp).Dispose();
        }
    }
