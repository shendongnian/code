    /// <summary>
    /// Used when dispatching code from the Factory (for example, SSL3 calls)
    /// </summary>
    /// <param name="flag">Make this guy have values for debugging support</param>
    public delegate void CodeDispatcher(ref string flag);
    /// <summary>
    /// Run code in SSL3 -- this is not thread safe. All connections executed while this
    /// context is active are set with this flag. Need to research how to avoid this...
    /// </summary>
    /// <param name="flag">Debugging context on exception</param>
    /// <param name="dispatcher">Dispatching code</param>
    public static void DispatchInSsl3(ref string flag, CodeDispatcher dispatcher)
    {
      var resetServicePoint = false;
      var origSecurityProtocol = System.Net.ServicePointManager.SecurityProtocol;
      try
      {
        System.Net.ServicePointManager.SecurityProtocol = System.Net.SecurityProtocolType.Ssl3;
        resetServicePoint = true;
        dispatcher(ref flag);
      }
      finally
      {
        if (resetServicePoint)
        {
          try { System.Net.ServicePointManager.SecurityProtocol = origSecurityProtocol; }
          catch { }
        }
      }
    }
