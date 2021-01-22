	public bool killProcess(int pid)
	{
		bool didIkillAnybody = false;
		try
		{
			Process[] procs = Process.GetProcesses();
			for (int i = 0; i < procs.Length; i++)
			{
				if (GetParentProcess(procsIdea.Id) == pid)
					if (killProcess(procsIdea.Id) == true)
						didIkillAnybody = true;
			}
			try
			{
				Process myProc = Process.GetProcessById(pid);
				myProc.Kill();
				return true;
			}
			catch { }
		}
		catch (Exception ex)
		{
			try
			{
				Logger log = new Logger();
				log.Write("Exception caught at JobExecution.killProcess()", ex.Message, System.Diagnostics.EventLogEntryType.Warning, false);
			}
			catch { }
		}
		return didIkillAnybody;
	}
	private int GetParentProcess(int Id)
	{
		int parentPid = 0;
		using (ManagementObject mo = new ManagementObject("win32_process.handle='" + Id.ToString() + "'"))
		{
			mo.Get();
			parentPid = Convert.ToInt32(mo["ParentProcessId"]);
		}
		return parentPid;
	}
