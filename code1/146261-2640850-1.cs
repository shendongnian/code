    public partial class MainPage : UserControl
	{
		public MainPage()
		{
			InitializeComponent();
			this.MediaElement.CurrentStateChanged += (sender, e) =>
			{
				this.Status.Text = this.MediaElement.CurrentState.ToString();
				this.Buffer.Visibility = this.MediaElement.CurrentState == MediaElementState.Buffering ? Visibility.Visible : Visibility.Collapsed;
			};
			this.MediaElement.BufferingProgressChanged += (sender, e) =>
			{
				this.Buffer.Text = string.Format("{0:0.0} %", this.MediaElement.BufferingProgress * 100);
			};
		}
		private void Play_Click(object sender, RoutedEventArgs e)
		{
			this.MediaElement.Play();
		}
		private void Pause_Click(object sender, RoutedEventArgs e)
		{
			this.MediaElement.Pause();
		}
		private void Stop_Click(object sender, RoutedEventArgs e)
		{
			this.MediaElement.Stop();
		}
	}
