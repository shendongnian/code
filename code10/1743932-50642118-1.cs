    try
    {
        throw new TimeoutException(); //or whatever BaseException's children
    }
    catch (BaseException e)
    {
        //here I'm assuming you know that you are swallowing the exception (which may be an anti-pattern)
        Console.WriteLine(e.GetString());
    }
