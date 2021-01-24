    public class CustomAttribute : System.Web.Mvc.AuthorizeAttribute
    {
        public override void OnAuthorization(AuthorizationContext context)
    	{
    		System.Net.Http.Headers.AuthenticationHeaderValue authorizationHeader = context.HttpContext.Request.Headers.Authorization;
    		
    		// Check that the Authorization header is present in the HTTP request and that it is in the
    		// format of "Authorization: Bearer <token>"
    		if ((authorizationHeader == null) || (authorizationHeader.Scheme.CompareTo("Bearer") != 0) || (String.IsNullOrEmpty(authorizationHeader.Parameter)))
			{
				// return HTTP 401 Unauthorized
			}
			
			using (WebClient client = new WebClient())
			{
				client.Headers.Add("Authorization", "Bearer " + authorizationHeader.Parameter);
				string userinfo = client.DownloadString("authURL/GetUserInfo");
				CustomUser user = JsonConvert.DeserializeObject<CustomUser>(userinfo);
				if (!user.Roles == this.Roles)
				{
						// I recommend return HTTP 403 Forbidden here, not 401. At this point
                        // the request has been authenticated via the bearer token, but the
                        // authenticated client does not have sufficient roles to execute the
                        // request, so they are forbidden from doing so. HTTP 401 Unauthorized
                        // is a bit of a misnomer because the actual intention is to determine
                        // whether or not the request is authenticated. HTTP 401 also implies
                        // that the request should be tried again with credentials, but that
                        // has already been done!
				}
			} 
		}
    }
