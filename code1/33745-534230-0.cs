    Bool bad = true;
    try
    {
       MightThrow();
       bad = false;
    }
    catch (SomePrivateMadeUpException foo)
    { 
       //empty
    }
    finally
    {
       if(bad) DoSomeLoggingOnFailure();   
    }
