    if (context.HandlerInstance is PageModel result) //using pattern matching
    {
        result.Response.StatusCode = 400;
        context.Result = result.Page();
    }
    
    await Task.CompletedTask;
