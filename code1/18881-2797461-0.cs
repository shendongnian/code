    try
    {
        int result = DoStuff(param);
    }
    catch (System.IO.IOException ioex)
    {
        if (ioex.Message.ToLowerInvariant().Contains("find me"))
        {
            .. do whatever ..
        }
        else
        {
            // no idea what just happened; we gotta crash
            throw;
        }
    }
