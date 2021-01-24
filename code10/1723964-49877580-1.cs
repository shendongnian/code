    public partial class TestWindow : Window
    {
    	public static readonly Guid Token = new Guid();
    	public TestWindow()
    	{
    		InitializeComponent();
    		Messenger.Default.Register<NotificationMessage>(this, Token, ResetColumnWidth);
    	}
    
    	private void ResetColumnWidth(NotificationMessage notMessage)
    	{
    		if (notMessage.Notification == "ResetColumnWidth")
    		{
    			foreach (DataGridColumn c in dg.Columns)
    			{
    				c.Width = 0;
    				c.Width = DataGridLength.Auto;
    			}
    		}
    	}
    }
