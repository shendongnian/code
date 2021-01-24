        /// <summary>
        /// Allows use of an authorisation attribute on controllers and controller methods
        /// </summary>
        public class ClaimsAuthorizeAttribute : AuthorizeAttribute
        {
            private string claimType;
            private string claimValue;
    
            /// <summary>
            /// Authorise using a claim by type (and optional value)
            /// </summary>
            /// <param name="type">The Claim Type - Usually [Controller]_[Action]</param>
            /// <param name="value">The Claim Value, usually one of Read | Edit | Create | Delete, or some other relevant value</param>
            public ClaimsAuthorizeAttribute(string type, string value = "")
            {
                this.ClaimType = type;
                this.ClaimValue = value;
            }
    
            /// <summary>
            /// Gets the Claim Type - Usually [Controller]_[Action]
            /// </summary>
            public string ClaimType { get => claimType; protected set => claimType = value; }
    
            /// <summary>
            /// Gets the Claim Value, usually one of Read | Edit | Create | Delete, or some other relevant value
            /// </summary>
            public string ClaimValue { get => claimValue; protected set => claimValue = value; }
    
            public override void OnAuthorization(AuthorizationContext filterContext)
            {
                // assume not authorised
                bool isAuthorised = false;
    
                // check user exists
                if (filterContext.HttpContext.User != null)
                {
                    // get user by claim principle
                    var user = filterContext.HttpContext.User as System.Security.Claims.ClaimsPrincipal;
    
                    if (user != null && user.HasClaim(ClaimType, ClaimValue))
                    {
                        // user has a claim of the correct type
                        isAuthorised = true;
                    }
                }
    
                if (isAuthorised)
                {
                    filterContext.Result = null;
                    base.OnAuthorization(filterContext);
                }
                else
                {
                    // we don't use 401 as this will cause a login loop :  base.HandleUnauthorizedRequest(filterContext);
                    // Forbidden message will be shown
                    filterContext.Result = new HttpStatusCodeResult(HttpStatusCode.Forbidden, "You are forbidden to access this resource");
                }
            }
        }
    }
