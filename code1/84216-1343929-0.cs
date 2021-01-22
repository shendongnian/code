    public class AuthorizeWithExemptionsAttribute : AuthorizeAttribute
    {
        public string Exemption { get; set; }
        public override void OnAuthorization(AuthorizationContext filterContext)
        {
            if (filterContext.RouteData.GetRequiredString("action") == Exemption)
                return;
            base.OnAuthorization(filterContext);
        }
    }
