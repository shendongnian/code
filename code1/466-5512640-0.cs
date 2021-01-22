    public static string GetFileProcessName(string filePath)
		{
				Process[] procs = Process.GetProcesses();
				string fileName = Path.GetFileName(filePath);
				foreach (Process proc in procs)
				{
					if (proc.MainWindowHandle != new IntPtr(0) && !proc.HasExited)
					{
						ProcessModule[] arr = new ProcessModule[proc.Modules.Count];
						foreach (ProcessModule pm in proc.Modules)
						{
							if (pm.ModuleName == fileName)
								return proc.ProcessName;
						}
					}
				}
			return null;
		}
