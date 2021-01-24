    services.Configure<ApiBehaviorOptions>(o =>
    {
        o.InvalidModelStateResponseFactory = actionContext =>
            new BadRequestObjectResult(actionContext.ModelState);
    });
