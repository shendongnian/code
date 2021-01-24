    [Headers("User-Agent: My Favorite User Agent!")]
    public interface IGitHubApi
    {
    	[Get("/users/{user}")]
    	Task<User> GetUser(string user);
    }
