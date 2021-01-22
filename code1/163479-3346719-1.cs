	public partial class MainWindow : Window
	{
		public MainWindow()
		{
			InitializeComponent();
		}
		private void Window_Loaded(object sender, RoutedEventArgs e)
		{
			NewActiveReport1 rpt = new NewActiveReport1();
			this.ARViewer.Document = rpt.Document;
			rpt.Run();
		}
	}
