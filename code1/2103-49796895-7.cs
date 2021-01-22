        using System.Diagnostics;
        static void Main()
        {
			Process ThisProcess = Process.GetCurrentProcess();
			Process[] AllProcesses = Process.GetProcessesByName(ThisProcess.ProcessName);
			if (AllProcesses.Length > 1)
			{
                //Don't put a MessageBox in here because the user could spam this MessageBox.
				return;
			}
