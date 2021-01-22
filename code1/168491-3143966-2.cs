    using System.Reflection;
    private static readonly ILog _logger = 
        LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);    
    public void SomeMethod()
    {
        _logger.DebugFormat("File not found: {0}", _filename);
    }
