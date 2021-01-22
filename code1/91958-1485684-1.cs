    //http://stackoverflow.com/questions/977071/redirecting-unauthorized-controller-in-asp-net-mvc/977112#977112
        [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method, Inherited = true, AllowMultiple = false)]
        public sealed class AuthorizeAttributeCustom : AuthorizeAttribute
        {
    
            /// <summary>
            /// The name of the view to render on authorization failure.  Default is "Error".
            /// </summary>
            public string ViewName { get; set; }
            public ViewDataDictionary ViewDataDictionary { get; set; }
            public DeniedAccessView DeniedAccessView { get; set; }
    
            private GoodRoles roleRequired = GoodRoles.None;
            public GoodRoles RoleRequired { get{ return roleRequired;} set{ roleRequired = value;} } // this may evolve into sets and intersections with an array but KISS
    
            public AuthorizeAttributeCustom()
            {
                ViewName = "DeniedAccess";
                DeniedAccessView = new DeniedAccessView
                                       {
                                           FriendlyName = "n/a",
                                           Message = "You do not have sufficient privileges for this operation."
                                       };
                ViewDataDictionary = new ViewDataDictionary(DeniedAccessView);
            }
    
            private void CacheValidateHandler(HttpContext context, object data, ref HttpValidationStatus validationStatus)
            {
                validationStatus = OnCacheAuthorization(new HttpContextWrapper(context));
            }
         
    
            public override void OnAuthorization(AuthorizationContext filterContext)
            {
    
                if (filterContext == null)
                {
                    throw new ArgumentNullException("filterContext");
                }
    
                if (!filterContext.HttpContext.User.Identity.IsAuthenticated)
                {
                    // auth failed, redirect to login page
                    filterContext.Result = new HttpUnauthorizedResult();
                    return;
                }
                
                if (RoleRequired == GoodRoles.None || filterContext.HttpContext.User.IsInRole(RoleRequired.ToString()))
                {
                    // is authenticated and is in the required role
                    SetCachePolicy(filterContext);
                    return;
                }
    
                filterContext.Result = new ViewResult { ViewName = ViewName, ViewData = ViewDataDictionary };
            }
    
            private void SetCachePolicy(AuthorizationContext filterContext)
            {
                // ** IMPORTANT **
                // Since we're performing authorization at the action level, the authorization code runs
                // after the output caching module. In the worst case this could allow an authorized user
                // to cause the page to be cached, then an unauthorized user would later be served the
                // cached page. We work around this by telling proxies not to cache the sensitive page,
                // then we hook our custom authorization code into the caching mechanism so that we have
                // the final say on whether a page should be served from the cache.
                HttpCachePolicyBase cachePolicy = filterContext.HttpContext.Response.Cache;
                cachePolicy.SetProxyMaxAge(new TimeSpan(0));
                cachePolicy.AddValidationCallback(CacheValidateHandler, null /* data */);
            }
    
    
        }
