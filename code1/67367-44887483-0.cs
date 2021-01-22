    void Application_Error(object sender, EventArgs e)
        {          
                    if (ex is HttpException && ex.InnerException is ViewStateException)
                    {
                        Response.Redirect(Request.Url.AbsoluteUri);
                        return;
                    }
        }
