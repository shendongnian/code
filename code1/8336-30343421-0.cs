    try
    {
        DoSomeHttpRequest();
    }
    catch (System.Web.HttpException e)
    {
        switch (e.GetHttpCode())
        {
            case 400:
                WriteLine("Bad Request");
            case 500:
                WriteLine("Internal Server Error");
            default:
                WriteLine("Generic Error");
        }
    }
