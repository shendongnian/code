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
                    return ;      //  if you need pass by , just set another flag in feature .
                }
                responseBody.Seek(0, SeekOrigin.Begin);
                using (var streamReader = new StreamReader(responseBody))
                {
                    // Get action result come from mvc pipeline
                    var strActionResult = streamReader.ReadToEnd();
                    var objActionResult = JsonConvert.DeserializeObject(strActionResult);
                    context.Response.Body = originBody;
                   // Create uniuqe shape for all responses.
                    var responseModel = new GenericResponseModel(objActionResult, (HttpStatusCode)context.Response.StatusCode, context.Items?["Message"]?.ToString());
                    // => Get error message
                    if (!ModelState.IsValid)
                    {
                        var errors= ModelState.Values.Where(v => v.Errors.Count > 0)
                            .SelectMany(v=>v.Errors)
                            .Select(v=>v.ErrorMessage)
                            .ToList();
                        responseModel.Result = null;
                        responseModel.Message = String.Join(" ; ",errors) ;
                    } 
                    // Set all response code to 200 and keep actual status code inside wrapped object.
                    context.Response.StatusCode = (int)HttpStatusCode.OK;
                    context.Response.ContentType = "application/json";
                    await context.Response.WriteAsync(JsonConvert.SerializeObject(responseModel));
                }
            }
        }
    }
