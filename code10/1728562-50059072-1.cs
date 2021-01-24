		public delegate void action();
		public static void WhenClosed(this Process process, action action)
		{
			var T = new System.Timers.Timer(1000);
			T.Elapsed += (s, e) =>
			{
				if (IntPtr.Zero == GetWindow(process.MainWindowHandle, GW_HWNDPREV))
				{
					T.Dispose();
					action();
				}
			};
			T.Start();
		}
