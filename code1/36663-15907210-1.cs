    public static void DoActionThenDisposePreservingActionException(Action action, IDisposable disposable)
    {
        bool exceptionThrown = true;
        Exception exceptionWhenNoDebuggerAttached = null;
        bool debuggerIsAttached = Debugger.IsAttached;
        ConditionalCatch(
            () =>
            {
                action();
                exceptionThrown = false;
            },
            (e) =>
            {
                exceptionWhenNoDebuggerAttached = e;
                throw new Exception("Catching exception from action(), see InnerException", exceptionWhenNoDebuggerAttached);
            },
            () =>
            {
                Exception disposeExceptionWhenExceptionAlreadyThrown = null;
                ConditionalCatch(
                    () =>
                    {
                        disposable.Dispose();
                    },
                    (e) =>
                    {
                        disposeExceptionWhenExceptionAlreadyThrown = e;
                        throw new Exception("Caught exception in Dispose() while unwinding for exception from action(), see InnerException for action() exception",
                            exceptionWhenNoDebuggerAttached);
                    },
                    null,
                    exceptionThrown && !debuggerIsAttached);
            },
            !debuggerIsAttached);
    }
    public static void ConditionalCatch(Action tryAction, Action<Exception> conditionalCatchAction, Action finallyAction, bool doCatch)
    {
        if (!doCatch)
        {
            try
            {
                tryAction();
            }
            finally
            {
                if (finallyAction != null)
                {
                    finallyAction();
                }
            }
        }
        else
        {
            try
            {
                tryAction();
            }
            catch (Exception e)
            {
                if (conditionalCatchAction != null)
                {
                    conditionalCatchAction(e);
                }
            }
            finally
            {
                if (finallyAction != null)
                {
                    finallyAction();
                }
            }
        }
    }
