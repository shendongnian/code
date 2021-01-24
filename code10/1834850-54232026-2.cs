	public partial class MainWindow : Window
	{
		private HubConnection Connection;
		private IHubProxy HubProxy;
		public MainWindow()
		{
			InitializeComponent();
			Task.Run(ConnectAsync);
		}
		private void Button_Click(object sender, RoutedEventArgs e)
		{
			using (var service = new ServiceReference1.Service1Client())
				service.GetData(1);
		}
		public async Task ConnectAsync()
		{
			try
			{
				this.Connection = new HubConnection("http://localhost:59082/");
				this.HubProxy = this.Connection.CreateHubProxy("ServiceMonitorHub");
				HubProxy.On("BroadcastMessage", () => MessageBox.Show("Received message!"));
				await this.Connection.Start();
			}
			catch (Exception ex)
			{
			}
		}
	}
