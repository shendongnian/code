        [AttributeUsage(AttributeTargets.Method, AllowMultiple = false)]
        public sealed class PutStuffInCacheAttribute : ActionFilterAttribute
        {
        	   // Fires before the action
           public override void OnActionExecuting(ActionExecutingContext filterContext)
            {
                base.OnActionExecuting(filterContext);
                    var context = filterContext.HttpContext;
        			SomeData result = (SomeData)context.Cache["reports"];
        			if (result == null)
        			{
        				var reports = new myReportsListClass();			
        				var result = reports.GetReportsData();
        				context.Cache.Add("reports", result);
        			}
        			
        			filterContext.RouteData.Values.Add("reports", result);
        		}	
        		
        		//Fires after the action but before view is complete.
            public override void OnActionExecuted(ActionExecutedContext filterContext)
            {
                base.OnActionExecuted(filterContext);
            }		
        	}
    	
