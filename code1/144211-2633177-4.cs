    public class HttpResponseMessageInspector : BehaviorExtensionElement, IDispatchMessageInspector, IServiceBehavior
    {
        public object AfterReceiveRequest(ref Message request, IClientChannel channel, InstanceContext instanceContext)
        {
            HttpRequestMessageProperty httpRequest = request.Properties[HttpRequestMessageProperty.Name]
            as HttpRequestMessageProperty;
            if (httpRequest != null)
            {
                string cookie = httpRequest.Headers[HttpRequestHeader.Cookie];
                if (!string.IsNullOrEmpty(cookie))
                {
                    FormsAuthentication.Decrypt(cookie);
                    FormsAuthenticationTicket authTicket = FormsAuthentication.Decrypt(cookie);
                    string[] roles = PrincipalHelper.GetUserRoles(authTicket);
                    var principal = new BreakpointPrincipal(new BreakpointIdentity(authTicket), roles);
                    HttpContext.Current.User = principal;                  
                }
                // can deny request here
            }
            return null;
        }
    }
