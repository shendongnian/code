    public static void Redirect(string VPathRedirect, global::System.Web.UI.Page Sender)
    {
        Sender.Response.Redirect(VPathRedirect, false);
        global::System.Web.UI.HttpContext.Current.ApplicationInstance.CompleteRequest();
    }
