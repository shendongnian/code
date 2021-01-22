    int x = ...;
    Action<Exception> handler = delegate(Exception ex)
    {
        // Same code for all exceptions of A, B or C.
        // You can use variable x here too.
    };    
    try
    {
    ...
    }
    catch (ExceptionTypeA ex) { handler(ex); }
    catch (ExceptionTypeB ex) { handler(ex); }
    catch (ExceptionTypeC ex) { handler(ex); }
