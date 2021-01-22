    try {
       DoSomething();
    }
    catch SomeException e {
       HandleException(e);
    }
    catch {
       throw ; // keep my stack trace.
    }
