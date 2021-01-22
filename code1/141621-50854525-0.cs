        [DllImport("kernel32.dll", SetLastError = true)] // Optional
		[return: MarshalAs(UnmanagedType.Bool)]          // Optional
        private void button1_Click(object sender, EventArgs e)
		{
			AllocConsole(); // Easy to read              // Optional
			Process[] processlist = Process.GetProcesses();
			foreach (Process process in processlist)
			{
				if (!string.IsNullOrEmpty(process.MainWindowTitle))
				{
					Console.WriteLine("Process: {0} ID: {1} Window title: {2}",
                    process.ProcessName, process.Id, process.MainWindowTitle);
				}
			}
		}
