    public class CustomTelemetry : ClientIpHeaderTelemetryInitializer
        {
            private readonly IHttpContextAccessor _httpContextAccessor ;
    
            public CustomTelemetry(IHttpContextAccessor httpContextAccessor) : base(httpContextAccessor)
            {
                _httpContextAccessor = httpContextAccessor;
            }
    
            /// <summary>
            /// Implements initialization logic.
            /// </summary>
            /// <param name="platformContext">Http context.</param>
            /// <param name="requestTelemetry">Request telemetry object associated with the current request.</param>
            /// <param name="telemetry">Telemetry item to initialize.</param>
            protected override void OnInitializeTelemetry(HttpContext platformContext, RequestTelemetry requestTelemetry, ITelemetry telemetry)
            {
                var userName = _httpContextAccessor.HttpContext?.User?.Identity?.Name; // Only set when request failed...
                var ip = _httpContextAccessor.HttpContext?.Connection?.RemoteIpAddress?.ToString();
                if (ip != null) telemetry.Context.GlobalProperties.TryAdd("InternalIP", ip);
                if(userName != null) requestTelemetry.Properties.Add("UserName", userName);
            }
         }
