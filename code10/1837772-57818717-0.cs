    protected override void OnException(ExceptionContext filterContext)
    {
     if (filterContext.Exception is Microsoft.Identity.Client.MsalUiRequiredException)
     {
       RedirectToAction("SignIn", "Account");
     }
     else {
        //Do your logging
        // ...
     }
    }
