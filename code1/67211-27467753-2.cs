    /// <summary>
    /// Executes a action with enabled System.Net.Logging with listener(s) at the code-site
    /// 
    /// Message from Microsoft:
    /// To configure you the listeners and level of logging for a listener you need a reference to the listener that is going to be doing the tracing. 
    /// A call to create a new TraceSource object creates a trace source with the same name as the one used by the System.Net.Sockets classes, 
    /// but it's not the same trace source object, so any changes do not have an effect on the actual TraceSource object that System.Net.Sockets is using.
    /// </summary>
    /// <param name="webTraceSourceLevel">The sourceLevel for the System.Net traceSource</param>
    /// <param name="httpListenerTraceSourceLevel">The sourceLevel for the System.Net.HttpListener traceSource</param>
    /// <param name="socketsTraceSourceLevel">The sourceLevel for the System.Net.Sockets traceSource</param>
    /// <param name="cacheTraceSourceLevel">The sourceLevel for the System.Net.Cache traceSource</param>
    /// <param name="actionToExecute">The action to execute</param>
    /// <param name="listener">The listener(s) to use</param>
    public static void ExecuteWithEnabledSystemNetLogging(SourceLevels webTraceSourceLevel, SourceLevels httpListenerTraceSourceLevel, SourceLevels socketsTraceSourceLevel, SourceLevels cacheTraceSourceLevel, Action actionToExecute, params TraceListener[] listener)
    {
        if (listener == null)
        {
            throw new ArgumentNullException("listener");
        }
    
        if (actionToExecute == null)
        {
            throw new ArgumentNullException("actionToExecute");
        }
    
        var logging = typeof(WebRequest).Assembly.GetType("System.Net.Logging");
        var isInitializedField = logging.GetField("s_LoggingInitialized", BindingFlags.NonPublic | BindingFlags.Static);
        if (!(bool)isInitializedField.GetValue(null))
        {
            //// force initialization
            HttpWebRequest.Create("http://localhost");
            Thread waitForInitializationThread = new Thread(() =>
            {
                while (!(bool)isInitializedField.GetValue(null))
                {
                    Thread.Sleep(100);
                }
            });
    
            waitForInitializationThread.Start();
            waitForInitializationThread.Join();
        }
    
        var isEnabledField = logging.GetField("s_LoggingEnabled", BindingFlags.NonPublic | BindingFlags.Static);
        var webTraceSource = (TraceSource)logging.GetField("s_WebTraceSource", BindingFlags.NonPublic | BindingFlags.Static).GetValue(null);
        var httpListenerTraceSource = (TraceSource)logging.GetField("s_HttpListenerTraceSource", BindingFlags.NonPublic | BindingFlags.Static).GetValue(null);
        var socketsTraceSource = (TraceSource)logging.GetField("s_SocketsTraceSource", BindingFlags.NonPublic | BindingFlags.Static).GetValue(null);
        var cacheTraceSource = (TraceSource)logging.GetField("s_CacheTraceSource", BindingFlags.NonPublic | BindingFlags.Static).GetValue(null);
    
        bool wasEnabled = (bool)isEnabledField.GetValue(null);
        Dictionary<TraceListener, TraceFilter> originalTraceSourceFilters = new Dictionary<TraceListener, TraceFilter>();
    
        //// save original Levels
        var originalWebTraceSourceLevel = webTraceSource.Switch.Level;
        var originalHttpListenerTraceSourceLevel = httpListenerTraceSource.Switch.Level;
        var originalSocketsTraceSourceLevel = socketsTraceSource.Switch.Level;
        var originalCacheTraceSourceLevel = cacheTraceSource.Switch.Level;
    
        //System.Net
        webTraceSource.Listeners.AddRange(listener);
        webTraceSource.Switch.Level = SourceLevels.All;
        foreach (TraceListener tl in webTraceSource.Listeners)
        {
            if (!originalTraceSourceFilters.ContainsKey(tl))
            {
                originalTraceSourceFilters.Add(tl, tl.Filter);
                tl.Filter = new ModifiedTraceFilter(tl, originalWebTraceSourceLevel, webTraceSourceLevel, originalHttpListenerTraceSourceLevel, httpListenerTraceSourceLevel, originalSocketsTraceSourceLevel, socketsTraceSourceLevel, originalCacheTraceSourceLevel, cacheTraceSourceLevel, listener.Contains(tl));
            }
        }
    
        //System.Net.HttpListener
        httpListenerTraceSource.Listeners.AddRange(listener);
        httpListenerTraceSource.Switch.Level = SourceLevels.All;
        foreach (TraceListener tl in httpListenerTraceSource.Listeners)
        {
            if (!originalTraceSourceFilters.ContainsKey(tl))
            {
                originalTraceSourceFilters.Add(tl, tl.Filter);
                tl.Filter = new ModifiedTraceFilter(tl, originalWebTraceSourceLevel, webTraceSourceLevel, originalHttpListenerTraceSourceLevel, httpListenerTraceSourceLevel, originalSocketsTraceSourceLevel, socketsTraceSourceLevel, originalCacheTraceSourceLevel, cacheTraceSourceLevel, listener.Contains(tl));
            }
        }
    
        //System.Net.Sockets
        socketsTraceSource.Listeners.AddRange(listener);
        socketsTraceSource.Switch.Level = SourceLevels.All;
        foreach (TraceListener tl in socketsTraceSource.Listeners)
        {
            if (!originalTraceSourceFilters.ContainsKey(tl))
            {
                originalTraceSourceFilters.Add(tl, tl.Filter);
                tl.Filter = new ModifiedTraceFilter(tl, originalWebTraceSourceLevel, webTraceSourceLevel, originalHttpListenerTraceSourceLevel, httpListenerTraceSourceLevel, originalSocketsTraceSourceLevel, socketsTraceSourceLevel, originalCacheTraceSourceLevel, cacheTraceSourceLevel, listener.Contains(tl));
            }
        }
    
        //System.Net.Cache
        cacheTraceSource.Listeners.AddRange(listener);
        cacheTraceSource.Switch.Level = SourceLevels.All;
        foreach (TraceListener tl in cacheTraceSource.Listeners)
        {
            if (!originalTraceSourceFilters.ContainsKey(tl))
            {
                originalTraceSourceFilters.Add(tl, tl.Filter);
                tl.Filter = new ModifiedTraceFilter(tl, originalWebTraceSourceLevel, webTraceSourceLevel, originalHttpListenerTraceSourceLevel, httpListenerTraceSourceLevel, originalSocketsTraceSourceLevel, socketsTraceSourceLevel, originalCacheTraceSourceLevel, cacheTraceSourceLevel, listener.Contains(tl));
            }
        }
    
        isEnabledField.SetValue(null, true);
    
        try
        {
            actionToExecute();
        }
        finally
        {
            //// restore Settings
            webTraceSource.Switch.Level = originalWebTraceSourceLevel;
            httpListenerTraceSource.Switch.Level = originalHttpListenerTraceSourceLevel;
            socketsTraceSource.Switch.Level = originalSocketsTraceSourceLevel;
            cacheTraceSource.Switch.Level = originalCacheTraceSourceLevel;
    
            foreach (var li in listener)
            {
                webTraceSource.Listeners.Remove(li);
                httpListenerTraceSource.Listeners.Remove(li);
                socketsTraceSource.Listeners.Remove(li);
                cacheTraceSource.Listeners.Remove(li);
            }
    
            //// restore filters
            foreach (var kvP in originalTraceSourceFilters)
            {
                kvP.Key.Filter = kvP.Value;
            }
    
            isEnabledField.SetValue(null, wasEnabled);
        }
    }
