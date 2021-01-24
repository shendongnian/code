    try
    {
        var session = new Session();
        try
        {
            //do stuff
        }
        finally
        {
            session.Dispose();
        }
    }
