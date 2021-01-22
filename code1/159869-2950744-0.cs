    // in usage...    
    [RequireLogin(AdditionalFields="amount,someotherfield")]
    [HttpPost]
    public ActionResult Bid(.....)
    
    // the attribute 
    class RequireLoginAttribute : ActionFilterAttribute
    {
    	public string AdditionalFields { get; set; }
    
    	public override void OnActionExecuting(ActionExecutingContext filterContext)
    	{
    		if (!filterContext.HttpContext.User.Identity.IsAuthenticated)
    		{
    			var returnUrl = filterContext.HttpContext.Request.RawUrl;
    			if (filterContext.HttpContext.Request.RequestType == "POST")
    			{
    				returnUrl = filterContext.HttpContext.Request.UrlReferrer.PathAndQuery;
    				// look for FORM values in request to append to the returnUrl
    				// this can be helpful for a good user experience (remembering checkboxes/text fields etc)
    			}
    
    			filterContext.Result = new RedirectResult(String.Concat("~/Account/LogOn", "?ReturnUrl=", returnUrl));
    			return;
    		}
    		base.OnActionExecuting(filterContext);
    	}
    }
