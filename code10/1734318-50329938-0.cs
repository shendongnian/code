    public async Task Invoke(HttpContext httpContext, IServiceProvider serviceProvider)
	{
		if (!httpContext.User.Identity.IsAuthenticated)
		{
			await httpContext.ChallengeAsync();
		}
        else { /* logic here */ }
	}
