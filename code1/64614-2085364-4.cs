    // usage (A): cross-thread invoke, messaging, custom task schedulers etc.
    catch (Exception e)
    {
        PreserveStackTrace (e) ;
        // store exception to be re-thrown later,
        // possibly in a different thread
        operationResult.Exception = e ;
    }
    // usage (B): after calling MethodInfo.Invoke() and the like
    catch (TargetInvocationException tiex)
    {
        PreserveStackTrace (tiex.InnerException) ;
        // unwrap TargetInvocationException, so that typed catch clauses 
        // in library/3rd-party code can work correctly;
        // new stack trace is appended to existing one
        throw tiex.InnerException ;
    }
