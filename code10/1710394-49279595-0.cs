       protected void Application_EndRequest()
            {                
                // redirected to the login page.
                var context = new HttpContextWrapper(Context);
                if (context.Request.IsAjaxRequest() && context.Response.StatusCode == 401)
                {
                    new RedirectResult("~/Account/Login");
                }
            }
        }
