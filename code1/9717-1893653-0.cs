    [DllImport("user32.dll")]
    private static extern uint GetWindowThreadProcessId(IntPtr hWnd, out uint lpdwProcessId);
    
    /// <summary> Tries to find and kill process by hWnd to the main window of the process.</summary>
    /// <param name="hWnd">Handle to the main window of the process.</param>
    /// <returns>True if process was found and killed. False if process was not found by hWnd or if it could not be killed.</returns>
    public static bool TryKillProcessByMainWindowHwnd(int hWnd)
    {
    	uint processID;
    	GetWindowThreadProcessId((IntPtr)hWnd, out processID);
    	if(processID == 0) return false;
    	try
    	{
    		Process.GetProcessById((int)processID).Kill();
    	}
    	catch (ArgumentException)
    	{
    		return false;
    	}
    	catch (Win32Exception)
    	{
    		return false;
    	}
    	catch (NotSupportedException)
    	{
    		return false;
    	}
    	catch (InvalidOperationException)
    	{
    		return false;
    	}
    	return true;
    }
    
    /// <summary> Finds and kills process by hWnd to the main window of the process.</summary>
    /// <param name="hWnd">Handle to the main window of the process.</param>
    /// <exception cref="ArgumentException">
    /// Thrown when process is not found by the hWnd parameter (the process is not running). 
    /// The identifier of the process might be expired.
    /// </exception>
    /// <exception cref="Win32Exception">See Process.Kill() exceptions documentation.</exception>
    /// <exception cref="NotSupportedException">See Process.Kill() exceptions documentation.</exception>
    /// <exception cref="InvalidOperationException">See Process.Kill() exceptions documentation.</exception>
    public static void KillProcessByMainWindowHwnd(int hWnd)
    {
    	uint processID;
    	GetWindowThreadProcessId((IntPtr)hWnd, out processID);
    	if (processID == 0)
    		throw new ArgumentException("Process has not been found by the given main window handle.", "hWnd");
    	Process.GetProcessById((int)processID).Kill();
    }
