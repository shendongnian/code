    public class TimeRangeFilterAttribute : Attribute, IAuthorizationFilter, IOrderedFilter
    {
        public string AllowedMonths { get; set; } // like |3|4|5|
        public string RedirectUrl { get; set; }
        public void OnAuthorization(AuthorizationFilterContext context)
        {
            if (not allowed) {
                context.Result = new RedirectResult(RedirectUrl);
            }
        }
    }
