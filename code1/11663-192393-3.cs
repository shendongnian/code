    namespace ForcingApostback
    {
        public partial class _Default : System.Web.UI.Page
        {
            protected void Page_Load(object sender, EventArgs e)
            {
                if (IsPostBack) Label1.Text = "Done postbacking!!!";
            }
    
            protected string getPostBackJavascriptCode()
            {
                return ClientScript.GetPostBackEventReference(this, null);
    
            }
        }
    }
