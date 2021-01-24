    class MyErrorResponseProvider : DefaultErrorResponseProvider
    {
    // note: in Web API the response type is HttpResponseMessage
    public override IActionResult CreateResponse( ErrorResponseContext context )
    {
           switch ( context.ErrorCode )
           {
               case "UnsupportedApiVersion":
                   context = new ErrorResponseContext(
                       context.Request,
                       context.StatusCode,
                       context.ErrorCode,
                       "My custom error message.",
                       context.MessageDetail );
                   break;
           }
           return base.CreateResponse( context );
    }
    }
