    namespace Demo{
    public partial class Control : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
		HttpContext.Current.Session["test"] = DateTime.Now.ToString();
        }
        // ALMOST A WEB METHOD
        public static string GetTest()
        {
            return " is " + HttpContext.Current.Session["test"];
        }
    }}
