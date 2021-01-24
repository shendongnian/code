    public async Task Invoke(HttpContext context)
    {
        context.Response.OnStarting(() =>
        {
            var fooService = context.RequestServices.GetService(typeof(FooService)) as FooService;
    
            var fooCount = fooService.Foos.Count; // always equals zero
    
            return Task.CompletedTask;
        });
    
        await this.next(context);    
    }
