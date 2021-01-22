    public class MyBaseClass : System.Web.UI.Page
    {
        protected override void OnLoad(EventArgs e)
        {
           // ... add custom logic here ...
           
           // Be sure to call the base class's OnLoad method!
           base.OnLoad(e);
        }
    }
    public class WebForm1 : MyBaseClass
    {
    	private void Page_Load(object sender, System.EventArgs e)
    	{
    		// Put user code to initialize the page here
    	}
    
        ...
    }
