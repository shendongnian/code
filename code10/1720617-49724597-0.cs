    private void SetUser()
    {
    	User user = new User();
    
    	if (this.Context.Request.Cookies.ContainsKey(UserCookieName))
    	{
    		user = JsonConvert.DeserializeObject<User>(this.Context.Request.Cookies[UserCookieName]);
    	}
    	else
    	{
    		user = JsonConvert.DeserializeObject<User>(InvokePost("CreateUser", new CreateUserContextModel() { User = user }).Result);
    	}
    
    	this.Context.Response.Cookies.Append(UserCookieName, JsonConvert.SerializeObject(user), new CookieOptions() { Expires = DateTime.Now.AddDays(120) });
    	this.User = user;
    }
    
    public User User { get; set; }
