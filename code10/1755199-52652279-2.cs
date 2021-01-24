    public override void OnException(HttpActionExecutedContext context) {
        //  Any custom AD API Exception thrown will be serialized into our custom response
        //  Any other exception will be handled by the Microsoft framework
        if (context.Exception is OurAdApiException contextException) {
            try {
                //  This lets us use HTTP Status Codes to indicate REST results.
                //  An invalid parameter value becomes a 400 BAD REQUEST, while
                //  a configuration error is a 503 SERVICE UNAVAILABLE, for example.
                //  (Code for CreateCustomErrorResponse available upon request...
                //   we basically copied the .NET framework code because it wasn't
                //   possible to modify/override it :(
                context.Response = context.Request.CreateCustomErrorResponse(contextException.HttpStatusCode, contextException);
            }
            catch (Exception exception) {                 
                exception.Swallow($"Caught an exception creating the custom response; IIS will generate the default response for the object");
            }
            
        }
    }
