	app.MapWhen(IsApiRequest, builder =>
	{
		builder.UseAntiforgeryTokens();
		var messageHandler = new BearerTokenRequestHandler(builder.ApplicationServices);
		var proxyOptions = new ProxyOptions
		{
			Scheme = "https",
			Host = "api.mydomain.com",
			Port = "443",
			BackChannelMessageHandler = messageHandler
		};
		builder.RunProxy(proxyOptions);
	});
    
	private static bool IsApiRequest(HttpContext httpContext)
	{
		return httpContext.Request.Path.Value.StartsWith(@"/api/", StringComparison.OrdinalIgnoreCase);
	}
