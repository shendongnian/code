    public async Task ExecuteResultAsync(ActionContext context)
    {
        // note: ObjectResult allows to pass null in ctor
        var objectResult = new ObjectResult(_value)
        {
            StatusCode = <needed status_code>
        };
    
        context.HttpContext.Response.Headers["Location"] = "<your relativeUri>";
    
        await objectResult.ExecuteResultAsync(context);
    }
