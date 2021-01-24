    public override async Task OnExceptionAsync(ExceptionContext context)
    {
        var db = context.HttpContext.RequestServices.GetService<AppIdentityDbContext>();
        
        ...
        await db.SaveChangesAsync();
    }
