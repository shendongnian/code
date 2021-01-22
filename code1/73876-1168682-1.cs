    public partial class test : System.Web.UI.Page
    {
        // Page_Load runs for EVERYTHING
        protected void Page_Load(object sender, EventArgs e)
        {
            // -- Constructor Area
            StringBuilder sb = new StringBuilder();
            // -- Page Init Area
            // -- ViewSate is loaded
            // -- Page Load Area
            if (!IsPostBack)
            {
                sb.Append("one");
                lbl.Text = sb.ToString();
            }
            // -- Validation controls are checked
            // -- If valid, start handling events
            // Handle your click event
            if (cmdSb_Clicked)
            {
                sb.Append("two");
                lbl.Text = sb.ToString();
            }
            // -- DataBinding Area
            // -- Save ViewState           
            // -- Render Page: the class is turned into html that is sent to the browser
            // -- Unload -- Page is disposed
    
        }
    }
