    //This would be defined in a Framework assembly that Plugins use
    public interface ILoggingService
    {
        //Various logging methods go here, including any overloads, like Debug, Trace, etc.
    }
    //This would be defined in one of your App assemblies that Plugins don't directly reference
    [Export(typeof(ILoggingService))]
    internal class AppLoggingService : ILoggingService
    {
        //Implementation of logging for your app
    }
    public class MyPlugin : IWatcherPluginBase
    {
        [Import] private ILoggingService _loggingService;
    }
