	public App() {
		this.Dispatcher.UnhandledException += OnDispatcherUnhandledException;
	}
	void OnDispatcherUnhandledException(object sender, System.Windows.Threading.DispatcherUnhandledExceptionEventArgs e) {
		string errorMessage = string.Format("An unhandled exception occurred: {0}", e.Exception.Message);
		MessageBox.Show(errorMessage, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
		e.Handled = true;
	}
