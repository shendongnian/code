    try
    {
        IDisposable x = new MyThing();
    }
    catch (Exception exception) // Use a more specific exception if possible.
    {
        x.ErrorOccurred = true; // You could even pass a reference to the exception if you wish.
        throw;
    }
    finally
    {
        x.Dispose();
    }
