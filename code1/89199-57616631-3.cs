    // KeepAlive.aspx.cs
    public partial class KeepSessionAlive: System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            // Refresh the current user session
            Session["refreshTime"] = DateTime.UtcNow;
        }
    }
