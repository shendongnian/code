    public class UserCheckModule : IHttpModule
    {
        public void Init(HttpApplication context)
        {
            context.PreRequestHandlerExecute += new EventHandler(OnPreRequestHandlerExecute);
        }
        public void Dispose() {}
    
        private void OnPreRequestHandlerExecute(object sender, EventArgs e)
        {
            // Get the user (though the method below is probably incorrect)
            // The basic idea is to get the user record using a user key
            // stored in the session (such as the user id).
            MembershipUser user = Membership.GetUser(Guid.Parse(HttpContext.Current.Session["guid"]));
            // Ensure user is valid
            if (!user.IsApproved)
            {
                HttpContext.Current.Session.Abandon();
                FormsAuthentication.SignOut();
                HttpContext.Current.Response.Redirect("~/Login.aspx?AccountDisabled");
            }
        }
    }
