    public class HangfireAuthorizationFilter : IDashboardAuthorizationFilter
    {
        public bool Authorize(DashboardContext context)
        {
            if (context.GetHttpContext().User.Identity.IsAuthenticated 
                  && context.GetHttpContext().User.IsInRole("admin"))
            {
                return true;
            }
            return false;
        }
    }
