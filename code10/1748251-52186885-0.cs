    public partial class MyTabbedPage : TabbedPage
	{
		public MyTabbedPage()
		{
			InitializeComponent();			
			CurrentPageChanged += CurrentPageHasChanged;
		}
		private void CurrentPageHasChanged(object sender, EventArgs e) => Title = CurrentPage.Title;
	}
