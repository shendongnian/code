    [DllImport("kernel32.dll", SetLastError=true)]
    static extern uint QueryDosDevice(string lpDeviceName, StringBuilder lpTargetPath, int ucchMax);
    
    public static bool IsSubstedPath(string path, out string realPath)
    {
    	StringBuilder pathInformation = new StringBuilder(250);
    	string driveLetter = null;
    	uint winApiResult = 0;
    
    	realPath = null;
    
    	try
    	{
    		// Get the drive letter of the path
    		driveLetter = Path.GetPathRoot(path).Replace("\\", "");
    	}
    	catch (ArgumentException)
    	{
    		return false;
    		//<------------------
    	}
    	
    	winApiResult = QueryDosDevice(driveLetter, pathInformation, 250);
    
    	if(winApiResult == 0)
    	{
    		int lastWinError = Marshal.GetLastWin32Error(); // here is the reason why it fails - not used at the moment!
    
    		return false;
    		//<-----------------
    	}
    
    	// If drive is substed, the result will be in the format of "\??\C:\RealPath\".
    	if (pathInformation.ToString().StartsWith("\\??\\"))
    	{
    		// Strip the \??\ prefix.
    		string realRoot = pathInformation.ToString().Remove(0, 4);
    
    		// add backshlash if not present
    		realRoot += pathInformation.ToString().EndsWith(@"\") ? "" : @"\";
    
    		//Combine the paths.
    		realPath = Path.Combine(realRoot, path.Replace(Path.GetPathRoot(path), ""));
    
    		return true;
    		//<--------------
    	}
    
    	realPath = path;
    
    	return false;
    }
