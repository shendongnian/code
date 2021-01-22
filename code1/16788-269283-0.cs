	public partial class Window1 : Window
	{
		public Window1()
		{
			InitializeComponent();
			FreezableCollection<SolidColorBrush> collection = new FreezableCollection<SolidColorBrush>();
			collection.Changed += collection_Changed;
			SolidColorBrush brush = new SolidColorBrush(Colors.Red);
			collection.Add(brush);
			brush.Color = Colors.Blue;
		}
		private void collection_Changed(object sender, EventArgs e)
		{
		}
	}
