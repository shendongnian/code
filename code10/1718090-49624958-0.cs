        var options = new GoogleOAuth2AuthenticationOptions()
        {
           ClientId = "someValue1",
           ClientSecret = "someValue2",
           Provider = new GoogleOAuth2AuthenticationProvider()
           {
            OnAuthenticated = (context) =>
             {
                //following line will add a new claim for profile image url
                context.Identity.AddClaim(new Claim("picUrl", ((Newtonsoft.Json.Linq.JValue)(context.User.SelectToken("image").SelectToken("url"))).Value.ToString()));
                return Task.FromResult(0);
             }
           }
    
        };
