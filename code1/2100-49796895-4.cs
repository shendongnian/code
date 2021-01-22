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
            string exeName = AppDomain.CurrentDomain.FriendlyName;
    		if (exeName != "the name of you're executable.exe") // If u try that in debug mode, don't forget that u don't use ur normal .exe. Debug uses the .vshost.exe.
    		{// You can add here a MassageBox if you want. To point users that the name got changed and maybe what the name should be or something like that^^ 
    			MessageBox.Show("The executable name should be \"the name of you're executable.exe\"", 
    			"Wrong executable name", MessageBoxButtons.OK, MessageBoxIcon.Error);
    			return;
    		}
            //Following Code is default code:
            Application.EnableVisualStyles();
			Application.SetCompatibleTextRenderingDefault(false);
			Application.Run(new MainForm());
        }
