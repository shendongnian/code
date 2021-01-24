        public override void OnResume()
		{
			base.OnResume();
			//...
			_refreshTimer = new System.Timers.Timer();
			_refreshTimer.Interval = 1000;
			_refreshTimer.Elapsed += RefreshView;
			_refreshTimer.Start();
		}
		public override void OnPause() 
		{
			base.OnPause();
			//...
			_refreshTimer.Dispose();
		}
