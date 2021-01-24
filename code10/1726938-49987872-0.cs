    protected int OriginalDuration { get; set; }
    
            public override void OnActionExecuting(ActionExecutingContext filterContext)
            {
                if(OriginalDuration == 0)
                {
                    OriginalDuration = Duration;
                }
    
                if ((filterContext.HttpContext.Request.QueryString[Config.QueryString.Expired] != null && filterContext.HttpContext.Request.QueryString[Config.QueryString.Expired].To<DateTime>().Date < DateTime.Now.Date.Date) || 
                   (filterContext.RouteData.Values[Config.QueryString.Expired] != null && filterContext.RouteData.Values[Config.QueryString.Expired].To<DateTime>().Date < DateTime.Now.Date.Date))
                {
                    Duration = (int)Config.Cache.TwoWeeks * 60;
                }
                else
                {
                    Duration = OriginalDuration;
                }
    
                base.OnActionExecuting(filterContext);
            }
