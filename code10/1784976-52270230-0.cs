	private static Subject<Unit> _check = new Subject<Unit>();
	private static IDisposable _subscription = null;
	
	private static void SetUp()
	{
		_subscription =
			_check
				.Select(x => Observable.Timer(TimeSpan.FromMinutes(15.0), TimeSpan.FromMinutes(1.0)))
				.Switch()
				.Subscribe(x => Program.SendAlertDiscord());
	}
	
	public static void Check()
	{
		_check.OnNext(Unit.Default);
	}
