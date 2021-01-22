    namespace Test
	{
	class MyTimer : System.Timers.Timer
		{
		public EventArgs MyEventArgs { get; set; }
		public MyTimer()
			{
			this.Elapsed += new System.Timers.ElapsedEventHandler(MyTimer_Elapsed);
			}
		void MyTimer_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
			{
			if (MyEventArgs != null)
				OnMyTimerElapsed(MyEventArgs);
			else
				OnMyTimerElapsed(e);
			}
		protected virtual void OnMyTimerElapsed(EventArgs ea)
			{
			if (MyTimerElapsed != null)
				{
				MyTimerElapsed(this, ea);
				}
			}
		public event EventHandler MyTimerElapsed;
		}
	}
