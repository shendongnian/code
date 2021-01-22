    // Error codes defined here: 
    // http://support.microsoft.com/kb/186550
    const int ERROR_FILE_NOT_FOUND = 2;
    const int ERROR_ACCESS_DENIED = 5;
    const int ERROR_NO_APP_ASSOCIATED = 1155; 
    void OpenFile(string filePath)
    {
    	Process process = new Process();
    
    	try
    	{
    		process.StartInfo.FileName = filePath;
    		process.StartInfo.Verb = "Open";
    		process.StartInfo.CreateNoWindow = true;
    		process.Start();
    	}
    	catch (Win32Exception e)
    	{
    		if (e.NativeErrorCode == ERROR_FILE_NOT_FOUND || 
    			e.NativeErrorCode == ERROR_ACCESS_DENIED ||
    			e.NativeErrorCode == ERROR_NO_APP_ASSOCIATED)
    		{
    			MessageBox.Show(this, e.Message, "Error", 
    					MessageBoxButtons.OK, 
    					MessageBoxIcon.Exclamation);
    		}
    	}
    }
