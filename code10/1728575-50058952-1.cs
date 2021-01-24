     public class AjaxAuthorizeAttribute: AuthorizeAttribute
        {
            protected override void HandleUnauthorizedRequest(AuthorizationContext filterContext)
            {
                if(filterContext.HttpContext.Request.IsAjaxRequest())
                {
                    UrlHelper urlhelper = new UrlHelper(filterContext.RequestContext);
                    filterContext.Result = new JsonResult
                    {
                        Data = new
                        {
                            Error = "NotAuthorize",
                            LogOnUrl = urlhelper.Action("LogOn", "Account")
                        },
                        JsonRequestBehavior = JsonRequestBehavior.AllowGet
                    };
                }else
                {
                    base.HandleUnauthorizedRequest(filterContext);
                }
            }
        }
