    namespace Demo{
    public partial class AjaxBridge : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
        }
        [WebMethod(EnableSession = true)]
        public static string Control_GetTest()
        {
            return Control.GetTest();
        }
    }}
