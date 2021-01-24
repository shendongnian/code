    public class Log
    {
    	private static readonly ILog someLogger = LogManager.GetLogger("SomeLogger");
    	static Log()
    	{
    		if (!UnitTestDetector.IsRunningFromNUnit)
    		{
    			XmlConfigurator.Configure(new FileInfo("log4net.config"));
    		}
    		else
    		{
    			var testDir = TestContext.CurrentContext.TestDirectory;
    			XmlConfigurator.Configure(new FileInfo(Path.Combine(testDir,"log4net.config")));
    		}
    	}
    
    	public static void Info(string msg)
    	{
    		someLogger.Info(msg);
    	}
    }
    
    static class UnitTestDetector
    {
    	static UnitTestDetector()
    	{
    		foreach (Assembly assem in AppDomain.CurrentDomain.GetAssemblies())
    		{
    			if (assem.FullName.ToLowerInvariant().StartsWith("nunit.framework"))
    			{
    				IsRunningFromNUnit = true;
    				break;
    			}
    		}
    	}
    
    	public static bool IsRunningFromNUnit { get; } = false;
    }
