    try
    {
        UserLogin();
    }
    catch(UnauthorizedException au)
    {
        Console.WriteLine("Unauthorized user... shutting down");
        //Closing Code...
        Environment.Exit(0);
    }
