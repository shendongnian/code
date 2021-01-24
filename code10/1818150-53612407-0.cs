    public class DiagnosticsMiddleware 
    {
        private readonly RequestDelegate _next;
		
        public DiagnosticsMiddleware(RequestDelegate next, IElasticClient esClient)
        {
            _next = next;
            _esClient = esClient;
        }
        public async Task Invoke(HttpContext context)
        { 
            Stopwatch sw = Stopwatch.StartNew();
           
            await _next(context);
            sw.Stop();
            var elapsedTime = sw.ElapsedTicks / (Stopwatch.Frequency / (1000L * 1000L));
			LogContext.PushProperty("ElapsedTime", elapsedTime);
        }
    }
