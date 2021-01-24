    public class RequestLogMiddleware
    {
        public class LogData {
            public IPAddress RemoteAddr {get;set;}
            public string User {get; set;}
            public int ResponseStatus {get; set;}
            public string RequestMethod {get;set;}
            public string RequestTimestamp {get;set;}
            public string RequestPath {get;set;}
            public string RequestProtocol {get;set;}
            public string UserAgent {get;set;}
            public long DurationMs {get;set;}
        }
        private readonly RequestDelegate _next;
        private readonly ILogger _logger;
        public RequestLogMiddleware(RequestDelegate next, ILoggerFactory factory)
        {
            _next = next;
            _logger = factory.CreateLogger("RequestLog");
        }
        private Func<LogData, string> _logLineFormatter;
        private Func<LogData,string> logLineFormatter{
            get  {
                if (this._logLineFormatter != null) {
                    return this._logLineFormatter;
                } 
                return this.DefaultFormatter();
            }
            set {
                this._logLineFormatter = value;
            }
        }
        /// <summary>
        /// Override this to set the default formatter if none was supplied
        /// </summary>
        /// <returns></returns>
        protected Func<LogData, string> DefaultFormatter() {
                return (logData => $"{logData.RemoteAddr} - {logData.User} {logData.RequestTimestamp} \"{logData.RequestMethod} {logData.RequestPath} {logData.RequestProtocol}\" {logData.ResponseStatus} \"{logData.UserAgent}\" {logData.DurationMs}ms");
        }
        /// <summary>
        /// Used to set a custom formatter for this instance
        /// </summary>
        /// <param name="formatter"></param>
        public void SetLogLineFormat(Func<LogData, string> formatter) {
            this._logLineFormatter = formatter;
        }
        public async Task Invoke(HttpContext context)
        {
            var now = DateTime.Now;
            var watch = Stopwatch.StartNew();
            await _next.Invoke(context);
            watch.Stop();
            var nowString = now.ToString("yyyy-MM-dd'T'HH:mm:ss.fffzzz", DateTimeFormatInfo.InvariantInfo);
            var user = context.User.Identity.Name ?? "-";
            var request = context.Request.Path +  (string.IsNullOrEmpty(context.Request.QueryString.ToString()) ? "" : context.Request.QueryString.ToString());
            var responseStatus = context.Response.StatusCode;
            var userAgent = context.Request.Headers.ContainsKey("User-Agent") ? context.Request.Headers["User-Agent"].ToString() : "-";
            var protocol = context.Request.Protocol;
            var duration = watch.ElapsedMilliseconds;
            var remoteAddr = context.Connection.RemoteIpAddress;    
            var method = context.Request.Method;
            var logData = new LogData {
                RemoteAddr = remoteAddr,
                RequestMethod = method,
                RequestPath = request,
                RequestProtocol = protocol,
                RequestTimestamp = nowString,
                ResponseStatus = responseStatus,
                User = user,
                UserAgent = userAgent,
                DurationMs = duration,
            };
            _logger.LogInformation(this.logLineFormatter(logData));
        }
    }
