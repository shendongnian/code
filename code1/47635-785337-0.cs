[Serializable]
public class MethodLoggingAttribute : OnMethodBoundaryAspect
{
    private ILog _logger;
    public override void OnEntry(MethodExecutionEventArgs eventArgs)
    {
        _logger = LogManager.GetLogger(eventArgs.Method.DeclaringType.ToString());
        if(ShowParameters = true)
        {
            _logger.DebugFormat("Entered {0} with args:{1}", eventArgs.Method.Name, args);
        }
        else
        {
            _logger.DebugFormat("Entered {0}", eventArgs.Method.Name);
        }
    }
    private bool m_ShowParameters;
    public bool ShowParameters
    {
        get { return m_ShowParameters; }
        set { m_ShowParameters = value; }
    }
}
