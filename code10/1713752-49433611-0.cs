    UserDetailsDTO userDetails = UserDetailService.GetUserdetailExternal(context.UserName, context.Password, userDetails.Iata);
    
    var identity = new ClaimsIdentity(context.Options.AuthenticationType);
    identity.AddClaim(new Claim("UserName", userDetails.UserName));
    identity.AddClaim(new Claim("Iata", userDetails.Iata));
    IDictionary<string, string> authProp = new Dictionary<string, string>()
    {
        { "UserName", userDetails.UserName },
        { "Iata", userDetails.Iata},
        { "UserDetails", Newtonsoft.Json.JsonConvert.SerializeObject(userDetails)}
    };
    var ticket = new AuthenticationTicket(identity, authProp);
    context.Validated(ticket); 
