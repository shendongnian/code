    public delegate void CancelledUserHandler();
    
    public partial class UserCancellationControl : System.Web.UI.UserControl
    {
        public event CancelledUserHandler UserCancelled;
        
        protected void CancelButtonClicked(object sender, EventArgs e)
        {
            // process the user's cancellation
            
            // fire off an event notifying listeners that a user was cancelled
            if (UserCancelled != null)
            {
                UserCancelled();
            }
        } 
    }
    
    public partial class MyPage : System.Web.UI.Page
    {
        protected UserCancellationControl myControl;
    
        protected void Page_Load(object sender, EventArgs e)
        {
            // hook up the ProcessCancelledUser method on this page
            // to respond to cancellation events from the user control
            myControl.UserCancelled += ProcessCancelledUser;
        }
    
        protected void ProcessCancelledUser()
        {
            // update the users status on the page
        }
    }
