    var principal = actionContext.RequestContext.Principal as ClaimsPrincipal;
    
                if (!principal.Identity.IsAuthenticated)
                {
                    actionContext.Response = actionContext.Request.CreateResponse(HttpStatusCode.Unauthorized);
                    return Task.FromResult<object>(null);
                }
    
                if (!(principal.HasClaim(x => x.Type == ClaimType && x.Value == ClaimValue)))
                {
                    actionContext.Response = actionContext.Request.CreateResponse(HttpStatusCode.Unauthorized);
                    return Task.FromResult<object>(null);
                }
    
                //User is Authorized, complete execution
                return Task.FromResult<object>(null);
