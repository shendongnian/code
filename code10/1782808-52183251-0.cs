    using Microsoft.AspNetCore.Authentication.Cookies;
    using Microsoft.AspNetCore.Authentication.JwtBearer;
    ...
    public void ConfigureServices(IServiceCollection services)
    {
    	services.AddAuthentication()
    		.AddCookie(CookieAuthenticationDefaults.AuthenticationScheme, options => { ...})
    		.AddJwtBearer(JwtBearerDefaults.AuthenticationScheme, options => {...})
    		.AddMicrosoftAccount(microsoftOptions => { ... })
    		.AddGoogle(googleOptions => { ... })
    		.AddTwitter(twitterOptions => { ... })
    		.AddFacebook(facebookOptions => { ... });
    
    }
