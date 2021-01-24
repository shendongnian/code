    public class MediaTypeResouceFilter : Attribute, IResourceFilter
        {
            public void OnResourceExecuting(ResourceExecutingContext context)
            {
            }
    
            public void OnResourceExecuted(ResourceExecutedContext context)
            {
                if (context.HttpContext.Response.StatusCode == 415)
                {
                    var jsonString = JsonConvert.SerializeObject(new { data = "this is custom message" });
                    byte[] data = Encoding.UTF8.GetBytes(jsonString);
                    context.HttpContext.Response.Body.WriteAsync(data, 0, data.Length);
                }
            }
        }
