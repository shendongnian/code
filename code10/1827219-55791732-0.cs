Microsoft.AspNetCore.Authentication.JwtBearer.JwtBearerHandler:Information: Failed to validate the token.
Microsoft.IdentityModel.Tokens.SecurityTokenInvalidIssuerException: IDX10205: Issuer validation failed. Issuer: 'https://spolujizda.b2clogin.com/4e8094c9-5058-454c-b201-ef61d7ae6619/v2.0/'. Did not match: validationParameters.ValidIssuer: 'null' or validationParameters.ValidIssuers: 'https://login.microsoftonline.com/4e8094c9-5058-454c-b201-ef61d7ae6619/v2.0/'.
   at Microsoft.IdentityModel.Tokens.Validators.ValidateIssuer(String issuer, SecurityToken securityToken, TokenValidationParameters validationParameters)
   at System.IdentityModel.Tokens.Jwt.JwtSecurityTokenHandler.ValidateIssuer(String issuer, JwtSecurityToken jwtToken, TokenValidationParameters validationParameters)
   at System.IdentityModel.Tokens.Jwt.JwtSecurityTokenHandler.ValidateTokenPayload(JwtSecurityToken jwtToken, TokenValidationParameters validationParameters)
   at System.IdentityModel.Tokens.Jwt.JwtSecurityTokenHandler.ValidateToken(String token, TokenValidationParameters validationParameters, SecurityToken& validatedToken)
   at Microsoft.AspNetCore.Authentication.JwtBearer.JwtBearerHandler.HandleAuthenticateAsync()
Microsoft.AspNetCore.Authentication.JwtBearer.JwtBearerHandler:Information: AzureADB2CJwtBearer was not authenticated. Failure message: IDX10205: Issuer validation failed. Issuer: 'https://spolujizda.b2clogin.com/4e8094c9-5058-454c-b201-ef61d7ae6619/v2.0/'. Did not match: validationParameters.ValidIssuer: 'null' or validationParameters.ValidIssuers: 'https://login.microsoftonline.com/4e8094c9-5058-454c-b201-ef61d7ae6619/v2.0/'.
Microsoft.AspNetCore.Mvc.Internal.ControllerActionInvoker:Information: Route matched with {action = "Get", controller = "Values"}. Executing action Spolujizda.ApiServer.Controllers.ValuesController.Get (Spolujizda.ApiServer)
Microsoft.AspNetCore.Authorization.DefaultAuthorizationService:Information: Authorization failed.
Microsoft.AspNetCore.Mvc.Internal.ControllerActionInvoker:Information: Authorization failed for the request at filter 'Microsoft.AspNetCore.Mvc.Authorization.AuthorizeFilter'.
Microsoft.AspNetCore.Mvc.ChallengeResult:Information: Executing ChallengeResult with authentication schemes ().
Microsoft.AspNetCore.Authentication.JwtBearer.JwtBearerHandler:Information: AuthenticationScheme: AzureADB2CJwtBearer was challenged.
Microsoft.AspNetCore.Mvc.Internal.ControllerActionInvoker:Information: Executed action Spolujizda.ApiServer.Controllers.ValuesController.Get (Spolujizda.ApiServer) in 8.105ms
Microsoft.AspNetCore.Hosting.Internal.WebHost:Information: Request finished in 8950.4739ms 401 text/plain
But for me the fix was much simpler.
