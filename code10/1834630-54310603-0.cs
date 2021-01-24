protected void Application_Start(object sender, EventArgs e)
{
  ConfigurationMonitor.Start();
}
where `ConfiguraitonMonitor` looks something like this:
public static class ConfigurationMonitor
{
    private static readonly Timer timer = new Timer(PollingInterval);
    public static bool MonitoringEnabled
    {
        get
        {
            return ((timer.Enabled || Working) ? true : false);
        }
    }
    private static int _PollingInterval;
    public static int PollingInterval
    {
        get
        {
            if (_PollingInterval == 0)
            {
                _PollingInterval = (Properties.Settings.Default.ConfigurationPollingIntervalMS > 0) ? Properties.Settings.Default.ConfigurationPollingIntervalMS : 5000;
            }
            return (_PollingInterval);
        }
        set { _PollingInterval = value; }
    }
    
    private static bool _Working = false;
    public static bool Working
    {
        get { return (_Working); }
    }
    public static void Start()
    {
        Start(PollingInterval);
    }
    /// <summary>
    /// Scans each DLL in a folder, building a list of the ConfigurationMonitor methods to call.
    /// </summary>
    private static List<ConfigurationMonitorAttribute> _MonitorMethods;
    private static List<ConfigurationMonitorAttribute> MonitorMethods
    {
        get
        {
            if (_MonitorMethods == null)
            {
                _MonitorMethods = new List<ConfigurationMonitorAttribute>();
                MonitorMethodsMessage = string.Empty;
                foreach (var assemblyFile in Directory.GetFiles(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "bin"), Properties.Settings.Default.ConfigurtionMonitorDLLPath))
                {
                    var assembly = Assembly.LoadFrom(assemblyFile);
                    foreach (ConfigurationMonitorAttribute monitor in assembly.GetCustomAttributes(typeof(ConfigurationMonitorAttribute), inherit: false))
                    {
                        _MonitorMethods.Add(monitor);
                    }
                }
            }
            return (_MonitorMethods);
        }
    }
    /// <summary>
    /// Resets and instanciates MonitorMethods property to refresh dlls being monitored
    /// </summary>
    public static void LoadMonitoringMethods()
    {
        _MonitorMethods = null;
        List<ConfigurationMonitorAttribute> monitorMethods = MonitorMethods;
    }
    /// <summary>
    /// Initiates a timer to monitor for configuration changes.
    /// This method is invoke on web application startup.
    /// </summary>
    /// <param name="pollingIntervalMS"></param>
    public static void Start(int pollingIntervalMS)
    {
        if (Properties.Settings.Default.ConfigurationMonitoring)
        {
            if (!timer.Enabled)
            {
                LoadMonitoringMethods();
                timer.Interval = pollingIntervalMS;
                timer.Enabled = true;
                timer.Elapsed += new ElapsedEventHandler(OnTimerElapsed);
                timer.Start();
            }
            else
            {
                timer.Interval = pollingIntervalMS;
            }
        }
    }
    public static void Stop()
    {
        if (Properties.Settings.Default.ConfigurationMonitoring)
        {
            if (timer.Enabled)
            {
                timer.Stop();
            }
        }
    }
    /// <summary>
    /// Monitors CE table for changes
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private static void OnTimerElapsed(object sender, ElapsedEventArgs e)
    {
        timer.Enabled = false;
        PollForChanges();
        timer.Enabled = true;
    }
    public static DateTime PollForChanges()
    {
        LastPoll = PollForChanges(LastPoll);
        return (LastPoll);
    }
    public static DateTime PollForChanges(DateTime lastPollDate)
    {
        try
        {
            _Working = true;
            foreach (ConfigurationMonitorAttribute monitor in MonitorMethods)
            {
                try
                {
                    lastPollDate = monitor.InvokeMethod(lastPollDate);
                    if (lastPollDate > LastRefreshDate)
                        LastRefreshDate = lastPollDate;
                }
                catch (System.Exception ex)
                {
                    // log the exception; my code omitted for brevity
                }
            }
        }
        catch (System.Exception ex)
        {
            // log the exception; my code omitted for brevity
            
        }
        finally
        {
            _Working = false;
        }
        return (lastPollDate);
    }
    #region Events
    /// <summary>
    /// Event raised when an AppDomain reset should occur
    /// </summary>
    public static event AppDomainChangeEvent AppDomainChanged;
    public static void OnAppDomainChanged(string configFile, IDictionary<string, object> properties)
    {
        if (AppDomainChanged != null) AppDomainChanged(null, new AppDomainArgs(configFile, properties));
    }
    #endregion
}
When we have a use case that wants to 'participate' in this polling mechanism, we tag some method with an attribute:
[assembly: ConfigurationMonitorAttribute(typeof(bar), "Monitor")]
namespace foo
{
  public class bar 
  {
    public static DateTime Monitor(DateTime lastPoll)
    {
      // do your expensive work here, setting values in your cache
    }
  }
}
> Our pattern of having the method triggered by `ConfigurationMonitor` returning a `DateTime` was a fairly bizarre edge case.  You could certainly go with a `void` method.
where the `ConfigurationMonitorAttribute` is something like this:
[AttributeUsage(AttributeTargets.Assembly, AllowMultiple = true)]
public class ConfigurationMonitorAttribute : Attribute
{
	private Type _type;
	private string _methodName;
	public ConfigurationMonitorAttribute(Type type, string methodName)
	{
		_type = type;
		_methodName = methodName;
	}
	public Type Type
	{
		get
		{
			return _type;
		}
	}
	public string MethodName
	{
		get
		{
			return _methodName;
		}
	}
	private MethodInfo _Method;
	protected MethodInfo Method
	{
		get
		{
			if (_Method == null)
			{
				_Method = Type.GetMethod(MethodName, BindingFlags.Static | BindingFlags.NonPublic | BindingFlags.Public);
				if (_Method == null)
					throw new ArgumentException(string.Format("The type {0} doesn't have a static method named {1}.", Type, MethodName));
			}
			return _Method;
		}
	}
	public DateTime InvokeMethod(DateTime lastPoll)
	{
		try
		{
			return (DateTime)Method.Invoke(null, new object[] { lastPoll });
		}
		catch (System.Exception err)
		{
			new qbo.Exception.ThirdPartyException(string.Format("Attempting to monitor {0}/{1} raised an error.", _type, _methodName), err);
		}
		return lastPoll;
	}
}
 
