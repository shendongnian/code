	private readonly Dispatcher _mainDispatcher;
	private readonly RequestHandler _requestHandler = new RequestHandler();
	public MainWindow()
	{
		InitializeComponent();
		_mainDispatcher = Dispatcher.CurrentDispatcher;
		_requestHandler.RenderProcessTerminated += OnBrowserRenderProcessTerminated;
		Browser.RequestHandler = _requestHandler;
	}
	
	private void OnBrowserRenderProcessTerminated(object sender, CefTerminationStatus e)
	{
		//Likely coming from a background thread
		_mainDispatcher.InvokeAsync(() =>
			Log.Error($"Browser crashed while at address: {Browser.Address}")
		);
	}
