    [ParseChildren(true, "MyTabs")]
    public partial class KITT_controls_tabgroup : System.Web.UI.UserControl
    {
    	private List<Tab> _myTabs;
    	[PersistenceMode(PersistenceMode.InnerProperty)]
    	public List<Tab> MyTabs
    	{
    		get
    		{
    			if (_myTabs == null)
    			{
    				_myTabs = new List<Tab>();
    			}
    			return _myTabs;
    		}
    
    	}
    
        protected void Page_Load(object sender, EventArgs e)
        {
    		rpContent.DataSource = MyTabs;
    		rpContent.DataBind();
    
        }
    	protected void rpContent_itemdatabound(Object Sender, RepeaterItemEventArgs e)
    	{
    
    		if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
    		{
    			Tab i = e.Item.DataItem as Tab;
    			i.TabContent.InstantiateIn(((PlaceHolder)e.Item.FindControl("plTabContent")));
    
    			((HyperLink)e.Item.FindControl("hlHeader")).Text = i.Title;
    		}
    	}
    }
