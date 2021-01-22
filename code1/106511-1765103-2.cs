	namespace WorkService
	{
		public partial class WorkService : ServiceBase
		{
			protected const int sleepMinutes = 30;
			protected System.Timers.Timer _interval;
			protected bool _running = false;
			public WorkService()
			{
				InitializeComponent();
				_interval = new System.Timers.Timer();
				_interval.Elapsed += new ElapsedEventHandler(OnTimedEvent);
				_interval.Interval = sleepMinutes * 60 * 1000;
				_running = false;
			}
			protected override void OnStart(string[] args)
			{
				_running = true;
				_interval.Enabled = true;
			}
			protected override void OnStop()
			{
				_interval.Enabled = false;
				_running = false;
			}
			private static void OnTimedEvent(object source, ElapsedEventArgs e)
			{
			    if(_running)
			        ActualWorkDoneHere();
			}
		}
	}
