    // example of first option. this applies ONLY when there is a
    // well-defined negative path or recovery scenario
    public void SomeFunction ()
    {
        try
        {
            string allText = System.IO.File.ReadAllText ();
        }
        // catch ONLY those exceptions you expect
        catch (System.ArgumentException e)
        {
            // ALWAYS log an error, expected or otherwise.
            _log.Warn ("Argument exception in SomeFunction", e);
            // if the use-case\control flow is recoverable, invoke
            // recovery logic, preferably out of try-catch scope
        }
    }
