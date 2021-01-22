	static List<Process> GetChildPrecesses()
	{
		string query = "Select * From Win32_Process Where ProcessID = " +Process.GetCurrentProcess().Id;
		ManagementObjectSearcher searcher = new ManagementObjectSearcher(query);
		ManagementObjectCollection processList = searcher.Get();
		List<Process> result=new List<Process>();
		foreach (ManagementObject obj in processList)
		{
			try
			{
				var p = Process.GetProcessById(Convert.ToInt32(obj.GetPropertyValue("ProcessId")));
				result.Add(p);
			}catch{}
		}
		return result;
	}
