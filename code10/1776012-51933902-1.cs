	[Application]
	public class App : Application, IGenericLifecycleObserver
	{
		public App(IntPtr javaReference, Android.Runtime.JniHandleOwnership transfer) : base(javaReference, transfer) { }
		bool Stopped;
		public void OnStateChanged(ILifecycleOwner p0, Lifecycle.Event p1)
		{
			Stopped |= p1 == Lifecycle.Event.OnStop;
			if (p1 == Lifecycle.Event.OnStart && Stopped)
			{
				// app is coming back from being in the background, do something...
				Stopped = false; // reset 
			}
		}
		public override void OnCreate()
		{
			base.OnCreate();
			ProcessLifecycleOwner.Get().Lifecycle.AddObserver(this);
        }
    }
