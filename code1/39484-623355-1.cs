    public partial class _Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            // hook up event handler for exposed user control event
            MyUserControl.UserControlButtonClicked += new  
                        EventHandler(MyUserControl_UserControlButtonClicked);
        }
        private void MyUserControl_UserControlButtonClicked(object sender, EventArgs e)
        {
            // ... do something when event is fired
        }
        
    }
