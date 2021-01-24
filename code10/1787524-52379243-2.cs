    public class ResponseFormatterMiddleware
    {
        // ...
        public async Task Invoke(HttpContext context)
        {
            var originBody = context.Response.Body;
            using (var responseBody = new MemoryStream())
            {
                context.Response.Body = responseBody;
                // Process inner middlewares and return result.
                await _next(context);
                var ModelState = context.Features.Get<ModelStateFeature>()?.ModelState;
                if (ModelState==null) {
                    return ;
                }
                responseBody.Seek(0, SeekOrigin.Begin);
                using (var streamReader = new StreamReader(responseBody))
                {
                    // ....
                    context.Response.Body = originBody;
                    // => Get error message
                    if (!ModelState.IsValid)
                    {
                        // do anything as you like 
                    } 
                    // ....
                }
            }
        }
    }
