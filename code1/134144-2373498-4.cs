		public TimedSample()
		{
			var weakListener = new WeakEventListener<TimedSample, DispatcherTimer, EventArgs>(this, timer);
			timer.Tick += weakListener.OnEvent;
			weakListener.OnEventAction = (instance, source, e) => instance.timer_Tick(source, e);		
			weakListener.OnDetachAction = (listener, source) => timer.Tick -= listener.OnEvent;
		}
