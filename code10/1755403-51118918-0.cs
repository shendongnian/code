    // …
    await _next(context);
    // …
    // Do nothing if a response body has already been provided.
    if (context.Response.HasStarted
        || context.Response.StatusCode < 400
        || context.Response.StatusCode >= 600
        || context.Response.ContentLength.HasValue
        || !string.IsNullOrEmpty(context.Response.ContentType))
    {
        return;
    }
    var statusCodeContext = new StatusCodeContext(context, _options, _next);
    await _options.HandleAsync(statusCodeContext);
