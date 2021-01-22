    static void Main()
        {
			Process ThisProcess = Process.GetCurrentProcess();
			Process[] AllProcesses = Process.GetProcessesByName(ThisProcess.ProcessName);
			if (AllProcesses.Length > 1)
			{
                //You could use a MessageBox but then the user could spam this MessageBox. So I just Use:
				return;
			}
