    public partial class WebUserControl : System.Web.UI.UserControl{
    public event EventHandler Updated;
    protected void Button1_Click(object sender, EventArgs e)
    {
        //do some work to this user control
        //raise the Updated event
        if (Updated != null)
            Updated(sender, e);
    }}
