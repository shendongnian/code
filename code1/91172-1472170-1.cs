    public partial class MyUserControl : System.Web.UI.UserControl
    {
        // Event Definition and Raising methods
        ...
        
        // Page Load Handler
        protected void Page_Load(object sender, EventArgs e)
        {
            // Add postback method to div's onClick
            divClickableDiv.Attributes.Add("onClick", 
                Page.ClientScript.GetPostBackEventReference(divClickableDiv, string.Empty));
            
            // This assumes this usercontrol will not have any other 
            // controls that can cause a postback other than 'divClickableDiv'
            if (IsPostBack)
            {
                // Raise click event for page to handle.
                OnDivClicked(EventArgs.Empty);
            }       
        }
    }
