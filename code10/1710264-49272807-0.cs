    public class BaseClass : UserControl, INotifyPropertyChanged
    {
    	public Path ConnIn;
    	public Path ConnOut;
    
    	public virtual ObjectBase BaseObject { get; set; }
    
    	public void BaseClass(XmlElementConfig config)
    	{
    		InitBase(config);
    	}
    	protected void InitBase(XmlElementConfig config)
    	{
    		if (BaseObject != null)
    		{
    			BaseObject.Title = config.Title;
    			BaseObject.GroupID = config.GroupID;
    		}
    	}
    }
    public DerivedClass(XmlElementConfig config) : base(config)
    {
    	InitializeComponent();
    	audio_objectAction = new Audio_MonitorAction(createGuid);
    	InitBase(config);
    }
