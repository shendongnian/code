         if (request.IsPasswordGrantType())
            {
                if (!Email_Regex_Validation.Check_Valid_Email_Regex(request.Username))
                {
                    return BadRequest(Resources.RegexEmail);
                }
                SpLoginUser stored = new SpLoginUser(_context);
                string result = stored.Usp_Login_User(request.Username, request.Password);
                if (!result.Contains("successfully"))
                {
                    return Forbid(OpenIddictServerDefaults.AuthenticationScheme);
                }
                // Create a new ClaimsIdentity holding the user identity.
                var identity = new ClaimsIdentity(
                    OpenIddictServerDefaults.AuthenticationScheme,
                    OpenIdConnectConstants.Claims.Name,
                    OpenIdConnectConstants.Claims.Role);
                identity.AddClaim(Resources.issuer, Resources.secret,
                    OpenIdConnectConstants.Destinations.IdentityToken);
                identity.AddClaim(OpenIdConnectConstants.Claims.Name, request.Username,
                    OpenIdConnectConstants.Destinations.IdentityToken);
                var ticket = new AuthenticationTicket(new ClaimsPrincipal(identity), new AuthenticationProperties(), OpenIdConnectServerDefaults.AuthenticationScheme);
                ticket.SetScopes(OpenIdConnectConstants.Scopes.OfflineAccess);
                // Ask OpenIddict to generate a new token and return an OAuth2 token response.
                return SignIn(ticket.Principal, ticket.Properties, ticket.AuthenticationScheme);
            }
