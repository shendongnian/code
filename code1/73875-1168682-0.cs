    public partial class test : System.Web.UI.Page
    {
        // Page_Load runs for EVERYTHING
        protected void Page_Load(object sender, EventArgs e)
        {
            //Constructor Area
            StringBuilder sb = new StringBuilder();
            // Page Load Area
            if (!IsPostBack)
            {
                sb.Append("one");
                lbl.Text = sb.ToString();
            }
            //Click Area
            if (cmdSb_Clicked)
            {
                sb.Append("two");
                lbl.Text = sb.ToString();
            }
    
        }
    }
