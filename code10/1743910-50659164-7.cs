    services.AddAuthentication(options =>
    {
    	options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    	options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;                
    }).AddIdentityServerAuthentication(JwtBearerDefaults.AuthenticationScheme,
    	options =>
    	{
    		options.Authority = "http://identitysrv";
    		options.TokenRetriever = CustomTokenRetriever.FromHeaderAndQueryString;
    		options.RequireHttpsMetadata = false;
    		options.ApiName = "publicAPI";
    	});
