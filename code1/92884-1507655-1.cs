    public class Tab
    	{
    	private string _sectionId;
    
    	public Tab(): this(String.Empty)
    		{
    		}
    	public Tab(string sectionid)
    	{
    		_sectionId = sectionid;
    	}
    
    	[Category("Behavior"),
    	DefaultValue(""),
    	Description("Section Id"),
    	NotifyParentProperty(true),
    	]
    	public String SectionId
    	{
    		get
    		{
    			return _sectionId;
    		}
    		set
    		{
    		_sectionId = value;
    		}
    	}
    }
