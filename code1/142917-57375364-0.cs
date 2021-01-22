	class A
	{
		public void something()
		{
			var myAction = 
				new Action<object, object>((sender, evArgs) => {
					MessageBox.Show("hiii, event happens " + (evArgs as  as System.Timers.ElapsedEventArgs).SignalTime); 
				});
			B.timer(myAction);
		}
	}
	class B
	{
		public static void timer( Action<object, System.Timers.ElapsedEventArgs> anyMethod)
		{
			System.Timers.Timer myTimer = new System.Timers.Timer();
			myTimer.Elapsed += new System.Timers.ElapsedEventHandler(anyMethod);
			myTimer.Interval = 2000;
			myTimer.Start();
		}
	}
