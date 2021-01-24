		public void Open(FileInfo epFile)
		{
			Process p = new Process();
			p.StartInfo.FileName = epFile.FullName;
			p.StartInfo.CreateNoWindow = true;
			p.EnableRaisingEvents = true;
			p.Start();
			try
			{
				var h = p.Handle; //Needed to know if the process is UWP
				p.Exited += (s, e) =>
				{
					// Code
				};
			}
			catch
			{
				GetLastWindow().WhenClosed(() =>
				{
					// Code
				});
			}
		}
		private Process GetLastWindow()
			=> Process.GetProcesses().OrderBy(GetZOrder).FirstThat(x => !string.IsNullOrEmpty(x.MainWindowTitle));
		[DllImport("user32.dll", SetLastError = true)]
		private static extern IntPtr GetWindow(IntPtr hWnd, int nIndex);
		const int GW_HWNDPREV = 3;
		private int GetZOrder(Process p)
		{
			IntPtr hWnd = p.MainWindowHandle;
			var z = 0;
			for (var h = hWnd; h != IntPtr.Zero; h = GetWindow(h, GW_HWNDPREV))
				z++;
			return z;
		}
