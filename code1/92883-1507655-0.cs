    [ParseChildren(true,"MyTabs")]
    public partial class QucikTabsControl :  System.Web.UI.UserControl
    {
    	
    	private List<Tab> _myTabs;
    	[PersistenceMode(PersistenceMode.InnerProperty)]
    	public List<Tab> MyTabs
    	{
    		get
    		{
    			if (_myTabs == null)
    			{
    				_myTabs =  new List<Tab>();
    			}
    			return _myTabs;
    		}
    
    	}
    }
    protected void Page_Load(object sender, EventArgs e)
    {
    	MyRepeater.DataSource = MyTabs.ToArray();
    	MyRepeater.DataBind();
    }
