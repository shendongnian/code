    /// <summary>
    /// The event occurs just after Initialization of Session, and before Page_Init event
    /// </summary>
    protected void Application_PreRequestHandlerExecute(Object sender, EventArgs e)
    {
        if (Session.IsNewSession || Session["CustomSessionId"] == null)
        {
            Response.Redirect("~/timeout.aspx");
        }
    }
