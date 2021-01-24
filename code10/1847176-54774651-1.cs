    //I am using WebForm4, but you can use a different page name
    public partial class WebForm4 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            form1.Action = Request.RawUrl;
        }
        [WebMethod]
        public static string DeleteMail(string fromID, string toID, string pagepath, string mailID)
        {
            //DB.TestForSomething();
            //above just does a basic INSERT straight into a test table in the 
            //database. since nothing is being inserted, I know this webmethod 
            //isn't getting used at all.
            return "SomeData";
        }
    }
