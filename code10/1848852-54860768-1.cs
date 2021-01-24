    public class Startup
	{
		public void Configuration(IAppBuilder app)
		{
			//var authority = JwtSecurityTokenHandler.DefaultInboundClaimTypeMap = new Dictionary<string, string>();
			JwtSecurityTokenHandler.DefaultInboundClaimTypeMap = new Dictionary<string, string>();
			app.UseCookieAuthentication(new CookieAuthenticationOptions
			{
				AuthenticationType = "Cookies"
			});
			app.UseOpenIdConnectAuthentication(new OpenIdConnectAuthenticationOptions
			{
				AuthenticationType = "oidc",				
				Authority = "http://localhost:5000",
				RedirectUri = "http://localhost:57319/signin-oidc",
				PostLogoutRedirectUri = "http://localhost:57319/signout-callback-oidc",
				ClientId = "mvc472",
				ClientSecret = "secret",
				ResponseType = "code id_token",
				Scope = "api01 openid profile offline_access",
				// for debug
				RequireHttpsMetadata = false,
				UseTokenLifetime = false,
				SignInAsAuthenticationType = "Cookies",
				Notifications = new OpenIdConnectAuthenticationNotifications
				{
					AuthorizationCodeReceived = async n =>
						{
							var client = new HttpClient();
							DiscoveryResponse disco = await client.GetDiscoveryDocumentAsync("http://localhost:5000");
							var tokenResponse = await client.RequestAuthorizationCodeTokenAsync(new AuthorizationCodeTokenRequest
							{
								Address = disco.TokenEndpoint,
								RedirectUri = "http://localhost:57319/signin-oidc",								
								ClientId = "mvc472",
								ClientSecret = "secret",
								Code = n.Code
							});
							var userInfoResponse = await client.GetUserInfoAsync(new UserInfoRequest
							{
								Address = disco.UserInfoEndpoint,
								Token = tokenResponse.AccessToken
							});
							var id = new ClaimsIdentity(n.AuthenticationTicket.Identity.AuthenticationType);
							id.AddClaims(userInfoResponse.Claims);
							id.AddClaim(new Claim("access_token", tokenResponse.AccessToken));
							id.AddClaim(new Claim("expires_at", DateTime.Now.AddSeconds(tokenResponse.ExpiresIn).ToLocalTime().ToString()));
							id.AddClaim(new Claim("refresh_token", tokenResponse.RefreshToken));
							id.AddClaim(new Claim("id_token", tokenResponse.IdentityToken));
							id.AddClaim(new Claim("sid", n.AuthenticationTicket.Identity.FindFirst("sid").Value));
							n.AuthenticationTicket = new AuthenticationTicket(
								new ClaimsIdentity(id.Claims, n.AuthenticationTicket.Identity.AuthenticationType, "name", "role"),
								n.AuthenticationTicket.Properties
								);
							
						},
					// noch nicht getestet
					RedirectToIdentityProvider = n =>
					{
						// if signing out, add the id_token_hint
						if (n.ProtocolMessage.RequestType == OpenIdConnectRequestType.Logout)
						{
							var idTokenHint = n.OwinContext.Authentication.User.FindFirst("id_token");
							if (idTokenHint != null)
							{
								n.ProtocolMessage.IdTokenHint = idTokenHint.Value;
							}
						}
						return Task.FromResult(0);
					}
				}
				
			});
		}
	}
