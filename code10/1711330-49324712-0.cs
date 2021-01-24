    public partial class MyUserControl : UserControl
	{
		DispatcherTimer m_timer = new DispatcherTimer();
		public MyUserControl()
		{
			InitializeComponent();
			m_timer.Tick += Timer_Tick;
			m_timer.Interval = TimeSpan.FromSeconds(4);
		}
		private void Timer_Tick(object sender, EventArgs e)
		{
			Window window = Window.GetWindow(this);
			window.IsEnabled = true;
			m_timer.Stop();
		}
		private void Button_Click(object sender, RoutedEventArgs e)
		{
			Window window = Window.GetWindow(this);
			window.IsEnabled = false;
			m_timer.Start();
			
		}
	}
