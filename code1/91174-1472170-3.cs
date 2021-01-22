    public partial class MyUserControl : System.Web.UI.UserControl
    {    
        // Event for page to handle
        public event EventHandler DivClicked;
    
        protected virtual void OnDivClicked(EventArgs e)
        {
            if (DivClicked != null)
                DivClicked(this, e);
        }        
    
        protected void Page_Load(object sender, EventArgs e)
        {
            // Page Load Code goes here
        }
    }
