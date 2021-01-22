    public static void RefreshMemory() {
    	try {
    		Process curProc = Process.GetCurrentProcess();
    		curProc.MaxWorkingSet = curProc.MaxWorkingSet;
    	} catch {
    		// Handle the exception
    	}
    }
