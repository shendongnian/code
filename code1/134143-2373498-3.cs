		static readonly DispatcherTimer timer; 
		static TimedSample()
		{
			timer = new DispatcherTimer() { Interval = TimeSpan.FromSeconds(1) };
			timer.Start();
		}
		public TimedSample()
		{
                   // Do not actually do this!
                   timer.Tick += timer_Tick;
		}
		private void timer_Tick(object sender, EventArgs e)
		{
			DateTime now = DateTime.Now;
			if (NowInRange != (Begin < now && now < End))
				NowInRange = !NowInRange;
		}
