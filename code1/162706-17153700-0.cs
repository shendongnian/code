    try
    {
        //do code here
    }
    catch (Exception ex)
    {
        try { SomeMethod1(); }
        catch { }
        try { SomeMethod2(); }
        catch { }
        try { SomeMethod3(); }
        catch { }
    }
    finally
    {
        //cleanup goes here
    }
