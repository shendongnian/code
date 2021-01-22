    public static int GetParentProcessId(int processId)
    {
    	string line;
    	using (StreamReader reader = new StreamReader ("/proc/" + processId + "/stat"))
    		  line = reader.ReadLine ();
    
    	int endOfName = line.LastIndexOf(')');
    	string [] parts = line.Substring(endOfName).Split (new char [] {' '}, 4);
    
    	if (parts.Length >= 3) 
    	{
    		int ppid = Int32.Parse (parts [2]);
    		return ppid;
    	}
    
    	return -1;
    }
