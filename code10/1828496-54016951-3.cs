    public class GlobalException
    {
        private readonly RequestDelegate _next;
        private readonly ILogger _logger;
        public GlobalException(RequestDelegate next, ILogger logger)
        {
            _logger = logger;
            _next = next;
        }
        public async Task InvokeAsync(HttpContext context)
        {
            HttpContext tempCtx = context; // had to contain the http context
            string request = await FormatRequest(context.Request);
            try
            {
                await _next(context);
            }
            catch (Exception ex)
            {
                ErrorLog log = new ErrorLog();
                UriBuilder builder = new UriBuilder();
                builder.Scheme = tempCtx.Request.Scheme;
                builder.Host = tempCtx.Request.Host.Host;
                builder.Path = tempCtx.Request.Path.ToString();
                builder.Query = tempCtx.Request.QueryString.ToString();
                log.LogDate = DateTime.Now;
                log.URL = builder.Uri.ToString();
                log.Request = request;
                log.Source = ex.Source;
                log.Message = ex.Message;
                await _logger.LogError(log); // custom logger
                await HandleExceptionAsync(context);
            }
        }
        private async Task<string> FormatRequest(HttpRequest request)
        {
            request.EnableRewind();
            var body = request.Body;
            byte[] buffer = new byte[Convert.ToInt32(request.ContentLength)];
            await request.Body.ReadAsync(buffer, 0, buffer.Length);
            string requestBody = Encoding.UTF8.GetString(buffer);
            body.Seek(0, SeekOrigin.Begin);
            request.Body = body;
            return requestBody;
        }
        private async Task HandleExceptionAsync(HttpContext context)
        {
            context.Response.ContentType = "application/json";
            context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
            BaseResponse<object> response = new BaseResponse<object>();
            response.Status = false;
            response.Message = "There is an exception occured.";
            response.Data = new List<object>();
            await context.Response.WriteAsync(response.Serialize());
        }
    }
