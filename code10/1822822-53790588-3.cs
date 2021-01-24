    public interface ILoggingService
    {
       void WriteLog(string strLog);
    }
    public class LoggingService : ILoggingService
    {
        private readonly IHostingEnvironment env;
        public LoggingService(IHostingEnvironment env)
        {
            this.env = env;
        }
        public void WriteLog(string strLog)
        {
            //Some code is Here
        }
    }
