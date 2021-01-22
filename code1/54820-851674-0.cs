		private Timer _timer;
		public Customer()
		{
			_timer = new Timer(UpdateDateTime, null, 0, 1000);
		}
		private void UpdateDateTime(object state)
		{
			TimeOfMostRecentActivity = DateTime.Now;
		}
