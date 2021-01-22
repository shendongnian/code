    try
    {
        int result = DoStuff(param);
    }
    catch (System.IO.IOException ex)
    {
        if (ex.Message.ToLowerInvariant().Contains("find me"))
        {
            //.. do whatever ..
        }
        else
        {
            throw;
        }
    }
