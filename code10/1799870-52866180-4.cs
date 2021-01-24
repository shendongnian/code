    public class CustomTelemetry: ITelemetryInitializer
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        public CustomTelemetry(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }
        public void Initialize(ITelemetry telemetry)
        {
            var requestTelemetry = telemetry as RequestTelemetry;
            if (requestTelemetry == null) return;
            if (!requestTelemetry.Context.Properties.ContainsKey("UserName"))
            {
                //if UserName is null or empty, add a default value for it
                if (string.IsNullOrEmpty(_httpContextAccessor.HttpContext.User.Identity.Name))
                {
                    requestTelemetry.Context.Properties.Add("UserName", "NA");
                }
                else
                {
                    requestTelemetry.Context.Properties.Add("UserName", _httpContextAccessor.HttpContext.User.Identity.Name);
                }
                
            }
            if (!requestTelemetry.Context.Properties.ContainsKey("InternalIP"))
            {
                //update
                if (!string.IsNullOrEmpty(requestTelemetry.Context.Location.Ip))
                {
                    requestTelemetry.Context.Properties.Add("InternalIP", requestTelemetry.Context.Location.Ip);                   
                }
            }
        }
    }
