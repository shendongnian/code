    private void AddAccountToCacheFromJwt(IEnumerable<string> scopes, JwtSecurityToken jwtToken, AuthenticationProperties properties, ClaimsPrincipal principal, HttpContext httpContext)
    {
     try
     {
      UserAssertion userAssertion;
      IEnumerable<string> requestedScopes;
      if (jwtToken != null)
      {
       userAssertion = new UserAssertion(jwtToken.RawData, "urn:ietf:params:oauth:grant-type:jwt-bearer");
       requestedScopes = scopes ?? jwtToken.Audiences.Select(a => $"{a}/.default");
      }
      else
      {
       throw new ArgumentOutOfRangeException("tokenValidationContext.SecurityToken should be a JWT Token");
       }
       var application = CreateApplication(httpContext, principal, properties, null);
       // Synchronous call to make sure that the cache is filled-in before the controller tries to get access tokens
       AuthenticationResult result = application.AcquireTokenOnBehalfOfAsync(scopes.Except(scopesRequestedByMsalNet), userAssertion).GetAwaiter().GetResult();
      }
      catch (MsalUiRequiredException ex)
      {
       ...
