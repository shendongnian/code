    public class MyDAL : BaseDal, IMyDAL
    {
        ILogger _log;
        public MyDAL(ILoggerFactory loggerFactory,IOptions<AppSettings> app):base(app)
        {
            _log = loggerFactory.CreateLogger("ChildDAL");
        }
    }
