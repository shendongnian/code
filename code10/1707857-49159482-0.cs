    if (!string.IsNullOrWhiteSpace(corrID?.ID))
    {
        context.Response.OnStarting((state) =>
        {
            context.Response.Headers.Add("Correlation-ID", corrID.ID);
            return Task.FromResult(0);
        }, context);
    }
    
    await _next(context);
