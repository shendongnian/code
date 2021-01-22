        /// <summary>
        ///     Event fires when an HTTP request is made to the application.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Application_PreRequestHandlerExecute(object sender, EventArgs e)
        {
            // If we don't have a logged in user.
            if (<BusinessDomain>.Constants.LoggedInUserID == null)
            {
                // Ensure that Context.Handler for this particular HTTP request implements an interface that uses a Session State.
                if (Context.Handler is IRequiresSessionState || Context.Handler is IReadOnlySessionState)
                {
                    if (Session != null)
                    {
                        // Set the currently logged in user in our Business Domain.
                        if ((Guid)Session["UserID"] != Guid.Empty)
                        {
                            <BusinessDomain>.Constants.LoggedInUserID = Session["UserID"];
                        }
                    }
                }
            }
        }
