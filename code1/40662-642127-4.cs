	public partial class UserLogon : UserControl
	{
		public UserLogon()
		{
			InitializeComponent();
			//would normally map view model to view with a DataTemplate, not manually like this
			DataContext = new LogonViewModel();
		}
	}
