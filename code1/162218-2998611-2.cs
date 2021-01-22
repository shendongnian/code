    // example of second option. this applies ONLY when there is no
    // well defined negative path and we require additional information
    // on failure
    public void SomeFunction ()
    {
        try
        {
            string allText = System.IO.File.ReadAllText ();
        }
        // catch ONLY those exceptions you expect
        catch (System.ArgumentException innerException)
        {
             // do whatever you need to do to identify this
             // problem area and provide additional context
             // like parameters or what have you. ALWAYS
             // provide inner exception
             throw new SomeCustomException (
                 "some new message with extra info.",
                 maybeSomeAdditionalContext,
                 innerException);
             // no requirement to log, assume caller will
             // handle appropriately
        }
    }
