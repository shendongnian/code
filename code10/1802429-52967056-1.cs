    services.ConfigureApplicationCookie(opt =>{
        opt.Events.OnSigningIn = async(signinContext)=>{
            
            // you can use the pricipal to query claims and roles as you need
            var x = signinContext.Principal.Claims.First(c=>c.Type=="X1" &&); 
            // set the expiration time according to claims/roles dynamically 
            signinContext.Properties.ExpiresUtc = DateTimeOffset.Now.AddSeconds(100);
            signinContext.CookieOptions.Expires = signinContext.Properties.ExpiresUtc?.ToUniversalTime();
 
        };
    });
