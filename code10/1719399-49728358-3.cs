    public void Configure(string name, OpenIdConnectOptions options)
    {
        options.ClientId = _azureOptions.ClientId;
        options.Authority = $"{_azureOptions.Instance}{_azureOptions.TenantId}";
        options.UseTokenLifetime = true;
        options.CallbackPath = _azureOptions.CallbackPath;
        options.RequireHttpsMetadata = false;
        //the new code
        options.Events = new OpenIdConnectEvents
        {
            OnTokenValidated = context =>
            {   
                var claimsIdentity = (ClaimsIdentity)context.Principal.Identity;
                //add your custom claims here
                claimsIdentity.AddClaim(new Claim("test", "helloworld!!!"));
                return Task.FromResult(0);
            }
        };
    }
