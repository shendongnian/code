    public partial class Dialog : Window
    {
    	public Dialog()
    	{
    		InitializeComponent();
    	}
    
    	protected override void OnClosed(EventArgs e)
    	{
    		if (host != null)
    		    host.Dispose();
    
    		base.OnClosed(e);
    	}
    }
