    using System.Diagnostics.
    
    Process me = Process.GetCurrentProcess();
    foreach (Process p in Process.GetProcesses())
    {
    	if (p.Id != me.Id && IntPtr.Zero != p.MainWindowHandle && false == p.ProcessName.Equals("explorer", StringComparison.CurrentCultureIgnoreCase))
    	{
    		// Sends WM_CLOSE; less gentle methods available too.
    		p.CloseMainWindow();
    	}
    }
