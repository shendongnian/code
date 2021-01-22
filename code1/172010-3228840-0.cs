    HttpApplication context = (HttpApplication)HttpContext.Current.ApplicationInstance;
                string authHeader = context.Request.Headers["Authorization"];
                string userNameAndPassword = Encoding.Default.GetString(
                           Convert.FromBase64String(authHeader.Substring(6)));
                string[] parts = userNameAndPassword.Split(':');
    
                Response.Write(userNameAndPassword);
