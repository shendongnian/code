			private async Task<string> GetAccessToken(string resourceId, string userName, string password)
				{
					try
						{
							var authority = ConfigurationManager.AppSettings["ida:AuthorizationLoginUri"] + ConfigurationManager.AppSettings["ida:TenantId"];
							var authContext = new AuthenticationContext(authority);
							var credentials = new UserPasswordCredential(userName, password);
							var authResult = await authContext.AcquireTokenAsync(resourceId, ConfigurationManager.AppSettings["ida:ClientIdNativeClient"], credentials);
							// Get the result
							return authResult.AccessToken;
						}
					catch (Exception ex)
						{
						// TODO: handle the exception
						return;
						}
				}
