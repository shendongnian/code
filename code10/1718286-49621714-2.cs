    /// <summary>
    /// The event occurs just after Initialization of Session, and before Page_Init event
    /// </summary>
    protected void Application_PostRequestHandlerExecute(object sender, EventArgs e)
    {
        if (Context.Handler is System.Web.SessionState.IRequiresSessionState
                    || Context.Handler is System.Web.SessionState.IReadOnlySessionState)
        {
            if (Session.IsNewSession || Session["CustomSessionId"] == null)
            {
                Response.Redirect("~/timeout.aspx");
            }
        }
    }
