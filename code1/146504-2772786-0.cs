    protected void Application_PreRequestHandlerExecute(Object sender, EventArgs e)
            {           
                if (HttpContext.Current.Session != null)
                {
                    if (HttpContext.Current.Session["userCultureInfo"] != null)
                    {
                        Thread.CurrentThread.CurrentUICulture = new CultureInfo(Session["userCultureInfo"].ToString());
               
                    }
                }
            }
