        [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method, AllowMultiple = false)]
        public class UserAuthorizeAttribute : System.Web.Http.Filters.ActionFilterAttribute
        {
            public override void OnActionExecuting(HttpActionContext actionContext)
            {
                try
                {
                    var authHeader = actionContext.Request.Headers.GetValues("Authorization").First();
                    if (string.IsNullOrEmpty(authHeader))
                    {
                        actionContext.Response = new HttpResponseMessage(System.Net.HttpStatusCode.BadRequest)
                        {
                            Content = new StringContent("Missing Authorization-Token")
                        };
                        return;
                    }
    
                    ClaimsPrincipal claimPrincipal = actionContext.Request.GetRequestContext().Principal as ClaimsPrincipal;
                    if (!IsAuthoticationvalid(claimPrincipal))
                    {
                        actionContext.Response = new HttpResponseMessage(System.Net.HttpStatusCode.BadRequest)
                        {
                            Content = new StringContent("Invalid Authorization-Token")
                        };
                        return;
                    }
    
                    if (!IsUserValid(claimPrincipal))
                    {
                        actionContext.Response = new HttpResponseMessage(System.Net.HttpStatusCode.BadRequest)
                        {
                            Content = new StringContent("Invalid User name or Password")
                        };
                        return;
                    }
    
                    //Finally role has perpession to access the particular function
                    if (!IsAuthorizationValid(actionContext, claimPrincipal))
                    {
                        actionContext.Response = new HttpResponseMessage(System.Net.HttpStatusCode.BadRequest)
                        {
                            Content = new StringContent("Permission Denied")
                        };
                        return;
                    }
    
                }
                catch (Exception ex)
                {
                    actionContext.Response = new HttpResponseMessage(System.Net.HttpStatusCode.BadRequest)
                    {
                        Content = new StringContent("Missing Authorization-Token")
                    };
                    return;
                }
    
                try
                {
                    //AuthorizedUserRepository.GetUsers().First(x => x.Name == RSAClass.Decrypt(token));
                    base.OnActionExecuting(actionContext);
                }
                catch (Exception)
                {
                    actionContext.Response = new HttpResponseMessage(System.Net.HttpStatusCode.Forbidden)
                    {
                        Content = new StringContent("Unauthorized User")
                    };
                    return;
                }
            }
    
            private bool IsAuthoticationvalid(ClaimsPrincipal claimPrincipal)
            {
                if (claimPrincipal.Identity.AuthenticationType.ToLower() == "bearer"
                    && claimPrincipal.Identity.IsAuthenticated)
                {
                    return true;
                }
                return false;
            }
    
            private bool IsUserValid(ClaimsPrincipal claimPrincipal)
            {
                string userID = claimPrincipal.Identity.GetUserId();
                var securityStamp = claimPrincipal.Claims.Where(c => c.Type.Equals("AspNet.Identity.SecurityStamp", StringComparison.OrdinalIgnoreCase)).Single().Value;
    
                var user = _context.AspNetUsers.Where(x => x.userID.Equals(userID, StringComparison.OrdinalIgnoreCase)
                    && x.SecurityStamp.Equals(securityStamp, StringComparison.OrdinalIgnoreCase));
                if (user != null)
                {
                    return true;
                }
                return false;
            }
    
            private bool IsAuthorizationValid(HttpActionContext actionContext, ClaimsPrincipal claimPrincipal)
            {
                string userId = claimPrincipal.Identity.GetUserId();
                string customerId = (string)actionContext.ActionArguments["CustomerId"];
                return AllowedToView(userId, customerId);
            }
    
            private bool AllowedToView(string userId, string customerId)
            {
                var customer = _context.WHERE(x => x.UserId == userId && x.CustomerId == customerId && x.RoleId == '1')
                return false;
            }
        }
