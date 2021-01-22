    public partial class MyUserControl : System.Web.UI.UserControl
    {
    
    public delegate void ButtonClickEventHandler(object sender,EventArgs e);
    public Event ButtonClickEventHandler Button_Click;
    
     protected void btnLogin_Click(object sender, EventArgs e)
            {
                if (Button_Click!= null)
                    Button_Click(sender,e);
            }
    }
