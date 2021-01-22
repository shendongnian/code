    public static void RetryBeforeThrow<T>(Action action, int retries, int timeout) where T : Exception
    {
        int tries = 1;
        do
        {
            try
            {
                action();
                return;
            }
            catch (T ex)
            {
                if (retries <= 0)
                {
                    PreserveStackTrace(ex);
                    throw;
                }
                Thread.Sleep(timeout);
            }
        }
        while (tries++ < retries);
    }
    /// <summary>
    /// Sets a flag on an <see cref="T:System.Exception"/> so that all the stack trace information is preserved 
    /// when the exception is re-thrown.
    /// </summary>
    /// <remarks>This is useful because "throw" removes information, such as the original stack frame.</remarks>
    /// <see href="http://weblogs.asp.net/fmarguerie/archive/2008/01/02/rethrowing-exceptions-and-preserving-the-full-call-stack-trace.aspx"/>
    public static void PreserveStackTrace(Exception ex)
    {
        MethodInfo preserveStackTrace = typeof(Exception).GetMethod("InternalPreserveStackTrace", BindingFlags.Instance | BindingFlags.NonPublic);
        preserveStackTrace.Invoke(ex, null);
    }
