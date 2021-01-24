    public override async Task OnAuthorizationAsync(HttpActionContext actionContext, CancellationToken token)
    {
        var auth = actionContext.Request.Headers.Authorization;
        string[] userInfo = Encoding.Default.GetString(Convert.FromBase64String(auth.Parameter)).Split(':');
        Profile user = new Profile();
        user.UserName = userInfo[0];
        user.Password = userInfo[1];
        HttpClient client = new HttpClient();
        client.BaseAddress = new Uri("http://localhost:31786");
        var response = await client.PostAsJsonAsync("api/token/request", user);
        //I hope to get the JWT Token back here or by this time the server should return it or set it in a cookie.
        return "OK";
    }
