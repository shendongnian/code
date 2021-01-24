    try
    {
        UserLogin();
        OtherMethod();
    }
    catch(UnauthorizedException au)
    {
        Console.WriteLine("Unauthorized user... shutting down");
        //Closing Code...
        Environment.Exit(0);
    }
    catch(OtherException oe)
    {
        //Closing Code...
        Environment.Exit(0);
    }
    ...
