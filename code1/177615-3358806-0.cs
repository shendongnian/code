    public class CoolControl : UserControl
    {
		public CoolControl()
		{
			InitializeComponent();
			Instances.Add(this);
		}
    	static IList<CoolControl> Instances = new List<CoolControl>();
    	
    	void SelectThisInstance()
    	{
			foreach(var instance in Instances)
			{
				// decrement z-index instance
			}
    		
    		// set z-index of this instance to show at top
    	}
    }
