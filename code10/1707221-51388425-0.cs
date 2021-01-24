    public class TelemetryHeadersInitializer : ITelemetryInitializer
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        public List<string> RequestHeaders { get; set; }
        public List<string> ResponseHeaders { get; set; }
        public TelemetryHeadersInitializer(IHttpContextAccessor httpContextAccessor)
        {
            RequestHeaders = new List<string> { "Referer" }; //whatever you need
            ResponseHeaders = new List<string> { ... };
            _httpContextAccessor = httpContextAccessor;
        }
        public void Initialize(ITelemetry telemetry)
        {
            var requestTelemetry = telemetry as RequestTelemetry;
            // Is this a TrackRequest() ?
            if (requestTelemetry == null) return;
            var context = _httpContextAccessor.HttpContext;
            if (context == null) return;
            foreach (var headerName in RequestHeaders)
            {
                var headers = context.Request.Headers[headerName];
                if (headers.Any())
                {
                    telemetry.Context.Properties.Add($"Request-{headerName}", string.Join(Environment.NewLine, headers));
                }             
            }
            foreach (var headerName in ResponseHeaders)
            {
                var headers = context.Response.Headers[headerName];
                if (headers.Any())
                {
                    telemetry.Context.Properties.Add($"Response-{headerName}", string.Join(Environment.NewLine, headers));
                }
            }
        }
    }
    //Services.cs:
    services.AddSingleton<ITelemetryInitializer, TelemetryHeadersInitializer>();
