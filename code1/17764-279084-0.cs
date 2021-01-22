    void doSomething()
    {
        using (CustomResource aResource = new CustomResource())
        {
            using (CustomThingy aThingy = new CustomThingy(aResource))
            {
                doSomething(aThingy);
            }
        }
    }
    
    void doSomething(CustomThingy theThingy)
    {
        try
        {
            // play with theThingy, which might result in exceptions
        }
        catch (SomeException aException)
        {
            // resolve aException somehow
        }
    }
