       public void Session_OnStart()
        {
            if (HttpContext.Current.Request.Cookies.Contains("ASP.NET_SessionId") != null)
            {
                HttpContext.Current.Response.Redirect("SessionTimeout.aspx")
            }
    
        }
