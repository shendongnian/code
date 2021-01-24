    public sealed class ErrorController : ControllerBase
    {
        // route will be /exceptions
        public async Task Exceptions() => await ExceptionalMiddleware.HandleRequestAsync(HttpContext);
    }
