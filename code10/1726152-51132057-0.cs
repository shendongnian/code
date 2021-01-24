    // skip IDX21323 exception
    if (context.Exception.Message.Contains("IDX21323"))
    {
       context.SkipToNextMiddleware();
    } else {
       context.HandleResponse();
       context.Response.Redirect("/Error?message=" + context.Exception.Message);
    }
    return Task.FromResult(0);
