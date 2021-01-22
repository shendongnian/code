    public partial class WebUserControl1 : System.Web.UI.UserControl
    	{
    		protected void Page_Load(object sender, EventArgs e)
    		{
    			LegoLand.DemoFolder.MasterPages.WebForm1 page = (WebForm1)this.Parent.Page;
    			page.SetMaster("** From the control to the master");
    			page.SetPageOutput("From the control to the page");
    		}
        }
