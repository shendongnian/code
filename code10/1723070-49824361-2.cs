    public YourClassConstructor(IAuthorizationService authService)
    {
       _authService = authService;
    }
    private IAuthorizationService _authService;
    public async Task SomeMethod()
    {
        var result = await _authService.AuthorizeAsync(user, PolicyName);
        if(result.Succeeded) 
        {
           //...
        }
    }
