           public class EntityFrameworkCoreSink : PeriodicBatchingSink
           {
        private readonly IFormatProvider _formatProvider;
        private readonly IServiceProvider _serviceProvider;
        private readonly JsonFormatter _jsonFormatter;
        static readonly object _lock = new object();
        public EntityFrameworkCoreSink(IServiceProvider serviceProvider, IFormatProvider formatProvider, int batchSizeLimit, TimeSpan period):base(batchSizeLimit, period)
        {
            this._formatProvider = formatProvider;
            this._serviceProvider = serviceProvider;
            this._jsonFormatter = new JsonFormatter(formatProvider: formatProvider);
        }
        protected override async Task EmitBatchAsync(IEnumerable<LogEvent> events)
        {
            using (var context = _serviceProvider.CreateScope().ServiceProvider.GetRequiredService<ApplicationDbContext>())
            {
                if (context != null)
                {
                    foreach (var logEvent in events)
                    {
                        var log = this.ConvertLogEventToLogRecord(logEvent);
                        await context.AddAsync(log);
                    }
                    await context.SaveChangesAsync();
                }
            }
        }
        private LogRecord ConvertLogEventToLogRecord(LogEvent logEvent)
        {
            if (logEvent == null)
            {
                return null;
            }
            string json = this.ConvertLogEventToJson(logEvent);
            JObject jObject = JObject.Parse(json);
            JToken properties = jObject["Properties"];
            return new LogRecord
            {
                Exception = logEvent.Exception?.ToString(),
                Level = logEvent.Level.ToString(),
                LogEvent = json,
                Message = this._formatProvider == null ? null : logEvent.RenderMessage(this._formatProvider),
                MessageTemplate = logEvent.MessageTemplate?.ToString(),
                TimeStamp = logEvent.Timestamp.DateTime.ToUniversalTime(),
                EventId = (int?)properties["EventId"]?["Id"],
                SourceContext = (string)properties["SourceContext"],
                ActionId = (string)properties["ActionId"],
                ActionName = (string)properties["ActionName"],
                RequestId = (string)properties["RequestId"],
                RequestPath = (string)properties["RequestPath"]
            };
        }
        private string ConvertLogEventToJson(LogEvent logEvent)
        {
            if (logEvent == null)
            {
                return null;
            }
            StringBuilder sb = new StringBuilder();
            using (StringWriter writer = new StringWriter(sb))
            {
                this._jsonFormatter.Format(logEvent, writer);
            }
            return sb.ToString();
        }
        }
