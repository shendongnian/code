    using NLog;
    using ILogger = ....Services.Support.ILogger;//from .Core project
    namespace ....Android.Services.Support//from .Droid project
    {
    public class AndroidLogger : ILogger
    {
        private readonly NLog.ILogger _logger;
		public AndroidLogger(string name)
		{
			_logger = LogManager.GetLogger(name);
		}
		.................
