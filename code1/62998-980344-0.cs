    public partial class MyUserControl : System.Web.UI.UserControl
    {
        public event EventHandler Changed;
    
        protected void Page_Load(object sender, EventArgs e)
        {
        }
    
        protected void ControlTextBox_Changed(object sender, EventArgs e)
        {
            OnChanged();
        }
    
        protected virtual void OnChanged()
        {
            if (Changed != null)
                Changed(this, EventArgs.Empty);
        }
    }
