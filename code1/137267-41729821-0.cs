    protected void Application_BeginRequest(object sender, EventArgs e)
    {
        //capture form data and preserve in query string
        if (Request.Form["txtTextField"]!= null)
        {
            Response.Redirect(Request.RawUrl + "?txtTextField=" 
              + Request.Form["txtTextField"]);
        }
        //or preserve in Session variable
        if(Request.Form["txtTextField"]!=null)
        {
            Session["txtTextField"]=Request.Form["txtTextField"];
        }
    }
