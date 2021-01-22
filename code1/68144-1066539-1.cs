    public partial class Window1 : Window
	{
		public Window1()
		{
			InitializeComponent();
			Names = new List<string>();
			Names.Add("Robert");
			Names.Add("Mike");
			Names.Add("steve");
			Names.Add("Jeff");
			Names.Add("bob");
			Names.Add("Dani");
			this.DataContext = this;
		}
		public List<String> Names { get; set; }
		private void OnFilterClick(object sender, RoutedEventArgs e)
		{
			uiListView.Items.Filter = x => x.ToString()[0] == x.ToString().ToUpper()[0];
		}
	}
