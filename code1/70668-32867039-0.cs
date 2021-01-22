        public void Application_PreRequestHandlerExecute(Object sender, EventArgs e)
        {
            // The code below is intended to block incoming HTTP GET requests which contains in query string parameters intended to be used in webform POST
            if (Request.HttpMethod != "GET")
            {
                return; // Nothing to do
            }
            var hasPostParams = (Request.QueryString["__EVENTTARGET"] ??
                                   Request.QueryString["__VIEWSTATE"] ??
                                   Request.QueryString["__EVENTARGUMENT"] ?? 
                                   Request.QueryString["__EVENTVALIDATION"]) != null;
            if (hasPostParams)
            {
               // TODO : log error (I suggest to also log HttpContext.Current.Request.RawUrl) and throw new exception
            }
        }
