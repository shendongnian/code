       protected void Application_EndRequest(object sender, EventArgs e)
        {
            // you could decide whether to redirect according to the path and status code
           string path = HttpContext.Current.Request.Path;
            if (HttpContext.Current.Response.StatusCode == 400)
            {
                HttpContext.Current.Response.Redirect("/ErrorPage.aspx");
            }
           
        }
