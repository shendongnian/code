    public partial class LoadingOverlayWindow : Window
	{
		/// <summary>
		///		Launches a loading window in its own UI thread and positions it over <c>overlayedElement</c>.
		/// </summary>
		/// <param name="overlayedElement"> An element for overlaying by the waiting form/message </param>
		/// <returns> A reference to the created window </returns>
		public static LoadingOverlayWindow CreateAsync(FrameworkElement overlayedElement)
		{
			// Get the coordinates where the loading overlay should be shown
			var locationFromScreen = overlayedElement.PointToScreen(new Point(0, 0));
			// Launch window in its own thread with a specific size and position
			var windowThread = new Thread(() =>
				{
					var window = new LoadingOverlayWindow
						{
							Left = locationFromScreen.X,
							Top = locationFromScreen.Y,
							Width = overlayedElement.ActualWidth,
							Height = overlayedElement.ActualHeight
						};
					window.Show();
					window.Closed += window.OnWindowClosed;
					Dispatcher.Run();
				});
			windowThread.SetApartmentState(ApartmentState.STA);
			windowThread.Start();
			// Wait until the new thread has created the window
			while (windowLauncher.Window == null) {}
			// The window has been created, so return a reference to it
			return windowLauncher.Window;
		}
		public LoadingOverlayWindow()
		{
			InitializeComponent();
		}
		private void OnWindowClosed(object sender, EventArgs args)
		{
			Dispatcher.InvokeShutdown();
		}
	}
