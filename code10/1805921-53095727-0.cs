    public partial class Contact : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Response.RedirectToRoute(new { controller = "Contact", action = "Index" });
        }
    }
