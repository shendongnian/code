    public partial class MyUserControl : System.Web.UI.UserControl
    {
        public event EventHandler UserControlButtonClicked;
    
        private void OnUserControlButtonClick()
        {
            if (UserControlButtonClicked != null)
            {
                UserControlButtonClicked(this, EventArgs.Empty);
            }
        }
    
        protected void TheButton_Click(object sender, EventArgs e)
        {
            // .... do stuff then fire off the event
            OnUserControlButtonClick();
        }
    
        // .... other code for the user control beyond this point
    }
