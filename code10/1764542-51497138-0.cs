    private Task OnUserInformationReceived(UserInformationReceivedContext c)
    {
        var userId = c.User.Value<string>("sub");    
        var dbContext = c.HttpContext.RequestServices.GetService<YourDbContext>();
        // Use dbContext here.
    
        return Task.CompletedTask;
    }
