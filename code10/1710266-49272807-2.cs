    public class BaseClass : UserControl, INotifyPropertyChanged
    {
    	public Path ConnIn;
    	public Path ConnOut;
    
    	public virtual ObjectBase BaseObject { get; set; }
    
    	public void BaseClass(XmlElementConfig config)
    	{
    		InitDerivedClass();
    		if (BaseObject != null)
    		{
    			BaseObject.Title = config.Title;
    			BaseObject.GroupID = config.GroupID;
    		}
    	}
    	protected virtual void InitDerivedClass() {}
    }
    public partial class DerivedClass : CanvasBase
    {
    	private Audio_MonitorAction audio_objectAction;
    
    	public override ObjectBase BaseObject
    	{
    		get { return audio_objectAction; }
    		set
    		{
    			audio_objectAction = (Audio_MonitorAction)value;
    			NotifyPropertyChanged();
    		}
    	}
    	protected override ObjectBase InitDerivedClass
    	{
    		audio_objectAction = new Audio_MonitorAction(createGuid);
    	}
    	public DerivedClass(XmlElementConfig config) : base(config)
    	{
    		InitializeComponent();
    	}
    }
