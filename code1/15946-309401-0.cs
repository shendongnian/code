    [ValidationProperty("Control2Ref")]
    public partial class Control1 : UserControl
    {
    	public string Control2Ref
    	{
    		get { return FindControl("Control2"); }
    	}
    	// rest of control 1 class
    }
