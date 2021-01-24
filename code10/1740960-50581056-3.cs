    public class YourPlugin : BasePlugin, IAdminMenuPlugin
    {
    	private readonly ISettingService _settingService;
    	private readonly IWebHelper _webHelper;
    
    	/**
    	 * Constructor
    	 **/
    	public YourPlugin(ISettingService settingService, IWebHelper webHelper)
    	{
    		this._settingService = settingService;
    		this._webHelper = webHelper;
    	}
    
    	/**
    	 * Adds the Admin Menu Item
    	 **/
    	public void ManageSiteMap(SiteMapNode rootNode)
    	{
    		var menuItem = new SiteMapNode()
    		{
    			SystemName = "Plugins.YourPlugin",
    			Title = "Your Plugin Title",
    			ControllerName = "YourPlugin",
    			ActionName = "Configure",
    			Visible = true,
    			RouteValues = new RouteValueDictionary() { { "area", null } },
    		};
    
    		// To add to the root Admin menu use
    		rootNode.ChildNodes.Insert(1, menuItem); // or rootNode.ChildNodes.Add(menuItem);
    	
    		/* uncomment to add to the "Plugins" Menu Item
    		var pluginNode = rootNode.ChildNodes.FirstOrDefault(x => x.SystemName == "Third party plugins");
    
    		if (pluginNode != null)
    			pluginNode.ChildNodes.Add(menuItem);
    		else
    			rootNode.ChildNodes.Add(menuItem);
    		*/
    	}
    }
