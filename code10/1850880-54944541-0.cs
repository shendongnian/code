    public override async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
    {
        bool valid=SomeMethod();
        if(valid)
             next();
        else
            context.Result = new BadRequestObjectResult("Invalid!");
    }
