    public partial class TabItemBinding : Window
	{
		public ObservableCollection<TextItem> Items { get; set; }
		public TabItemBinding()
		{
			Items = new ObservableCollection<TextItem>();
			Items.Add(new TextItem() { Header = "1", Content = new TextBox() { Text = "First item" } });
			Items.Add(new TextItem() { Header = "2", Content = new TextBox() { Text = "Second item" } });
			Items.Add(new TextItem() { Header = "3", Content = new TextBox() { Text = "Third item" } });
			InitializeComponent();
		}
	}
	public class TextItem
	{
		public string Header { get; set; }
		public FrameworkElement Content { get; set; }
	}
