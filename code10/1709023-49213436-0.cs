    public partial class Page2 : System.Web.UI.Page
    {
    
            protected void Page_Load(object sender, EventArgs e)
            {
                 string k3 = System.Web.HttpContext.Current.Session["k3"].ToString(); //Not Working.
                 string k4 = System.Web.HttpContext.Current.Session["k4"].ToString(); //Not Working.
            }
    }
