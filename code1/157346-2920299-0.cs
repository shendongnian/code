    [ThreadStatic]
    static readonly log4net.ILog _log;
    static string log {
       get {
         if (null == _log) {
             _log = log4net.LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);
         }
         return _log;
       }
    }
