    public partial class Window1 : Window
	{
		public Window1()
		{
			InitializeComponent();
		}
		public ObservableCollection<string> TestItems
		{
			get
			{
				return new ObservableCollection<string>()
				{
					"Item 1", "Item 2", "Item 3"
				};
			}
		}
		private void OnMenuItemClick(object sender, RoutedEventArgs e)
		{
			MenuItem item = e.Source as MenuItem;
			if (item.Name == "MenuItemDelete")
			{
				// Delete the item.
			}
			else if (item.Name == "MenuItemAdd")
			{
				// Add the item.
			}
		}
	}
