    // sorta sucks, let's be honest...
    try
    {
        // try some stuff
    }
    catch( Exception ex )
    {
        if (ex is FormatException ||
            ex is OverflowException ||
            ex is ArgumentNullException)
        {
            // write to a log, whatever...
            return;
        }
        throw;
    }
