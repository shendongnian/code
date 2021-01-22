    public sealed class SqlLogger:ILogger
    { 
        private ILog _logger;
        public SqlLogger()
        {            
            log4net.Config.BasicConfigurator.Configure(GetAppender());
            this._logger = log4net.LogManager.GetLogger(CrmConfigHelper.GetString(Constants.LOG4NET_LOGGER_NAME));
        }
        private log4net.Appender.AdoNetAppender GetAppender()
        {            
            log4net.Appender.AdoNetAppender appender = new log4net.Appender.AdoNetAppender();
            appender.ConnectionType = CrmConfigHelper.GetString(Constants.LOG4NET_CONNECTION_TYPE);
            appender.ConnectionString = CrmConfigHelper.GetString(Constants.LOG4NET_DB_CONNECTION);
            appender.BufferSize = CrmConfigHelper.getInteger(Constants.LOG4NET_BUFFER_SIZE);
            appender.CommandText = "INSERT INTO [EventLog] ([Date],[HostName],[Level],[Logger],[Message],[Exception]) VALUES (@log_date, @hostname, @log_level, @logger, @message,@exception)";
            appender.CommandType = System.Data.CommandType.Text;
            appender.AddParameter(new log4net.Appender.AdoNetAppenderParameter() { 
                ParameterName = "@log_date",
                DbType = System.Data.DbType.DateTime,
                Size = 100,
                Layout = new RawLayoutConverter().ConvertFrom(new PatternLayout("%date{yyyy'-'MM'-'dd HH':'mm':'ss'.'fff}")) as IRawLayout
            });
            appender.AddParameter(new log4net.Appender.AdoNetAppenderParameter()
            {
                ParameterName = "@hostname",
                DbType = System.Data.DbType.String,
                Size = 50,
                Layout = new RawLayoutConverter().ConvertFrom(new PatternLayout("%property{log4net:HostName}")) as IRawLayout
            });
            appender.AddParameter(new log4net.Appender.AdoNetAppenderParameter()
            {
                ParameterName = "@log_level",
                DbType = System.Data.DbType.String,
                Size = 50,
                Layout = new RawLayoutConverter().ConvertFrom(new PatternLayout("%level")) as IRawLayout
            });
            appender.AddParameter(new log4net.Appender.AdoNetAppenderParameter()
            {
                ParameterName = "@logger",
                DbType = System.Data.DbType.String,
                Size = 50,
                Layout = new RawLayoutConverter().ConvertFrom(new PatternLayout("%logger")) as IRawLayout
            });
            appender.AddParameter(new log4net.Appender.AdoNetAppenderParameter()
            {
                ParameterName = "@message",
                DbType = System.Data.DbType.String,
                Size = 4000,
                Layout = new RawLayoutConverter().ConvertFrom(new PatternLayout("%message")) as IRawLayout
            });
            appender.AddParameter(new log4net.Appender.AdoNetAppenderParameter()
            {
                ParameterName = "@exception",
                DbType = System.Data.DbType.String,
                Size = 2000,
                Layout = new RawLayoutConverter().ConvertFrom(new ExceptionLayout()) as IRawLayout
            });
            
            appender.ActivateOptions();
            return appender;
        }
        public void Error(RuntimeContext context)
        {
            _logger.Error(context.ToJsonString());
        }
        
        public void Error(RuntimeContext context, Exception exception)
        {
            _logger.Error(context.ToJsonString(), exception);
        }
        public void Warn(RuntimeContext context)
        {
            _logger.Warn(context.ToJsonString());
        }
        public void Warn(RuntimeContext context, Exception exception)
        {
            _logger.Warn(context.ToJsonString(), exception);
        }
        public void Info(RuntimeContext context)
        {
            _logger.Info(context.ToJsonString());
        }
        public void Info(RuntimeContext context, Exception exception)
        {
            _logger.Info(context.ToJsonString(), exception);
        }
    }
    public interface ILogger
    {
        void Error(Message context);
        void Error(Message context, Exception exception);
        void Warn(Message context);
        void Warn(Message context, Exception exception);
        void Info(Message context);
        void Info(Message context, Exception exception);
   }
    public sealed class Message
    {
        public string RunDate { get; set; }
        public string RunBy { get; set; }
        public string Message { get; set; }
        public string ToJsonString()
        {
            return new JavaScriptSerializer().Serialize(this);
        }
    }
