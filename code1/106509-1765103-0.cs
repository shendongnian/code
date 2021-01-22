	namespace WorkService
	{
		public partial class WorkService : ServiceBase
		{
			protected const int sleepMinutes = 30;
			System.Timers.Timer _interval;
			public WorkService()
			{
				InitializeComponent();
				_interval = new System.Timers.Timer();
				_interval.Elapsed += new ElapsedEventHandler(OnTimedEvent);
				_interval.Interval = sleepMinutes * 60 * 1000;
			}
			protected override void OnStart(string[] args)
			{
				_interval.Enabled = true;
			}
			protected override void OnStop()
			{
				_interval.Enabled = false;
			}
			private static void OnTimedEvent(object source, ElapsedEventArgs e)
			{
				ActualWorkDoneHere();
			}
		}
	}
