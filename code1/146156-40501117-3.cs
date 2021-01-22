    using System.Management;
    using System.ComponentModel;
    
    // Note: The class must be static in order to be able to define an extension method.
    static class Progam
    {	
    	private static void Main()
    	{
    		foreach (var process in Process.GetProcesses())
    		{
    			try
    			{
    				Console.WriteLine($"PID: {process.Id}; cmd: {process.GetCommandLine()}");
    			}
    			// Catch and ignore "access denied" exceptions.
    			catch (Win32Exception ex) when (ex.HResult == -2147467259) {}
    			// Catch and ignore "Cannot process request because the process (<pid>) has
                // exited." exceptions.
    			// These can happen if a process was initially included in 
                // Process.GetProcesses(), but has terminated before it can be
                // examined below.
    			catch (InvalidOperationException ex) when (ex.HResult == -2146233079) {}
    		}
    	}
    
    	// Define an extension method for type System.Process that returns the command 
        // line via WMI.
    	private static string GetCommandLine(this Process process)
    	{
    		string cmdLine = null;
    		using (var searcher = new ManagementObjectSearcher(
              $"SELECT CommandLine FROM Win32_Process WHERE ProcessId = {process.Id}"))
    		{
    			// By definition, the query returns at most 1 match, because the process 
                // is looked up by ID (which is unique by definition).
    			using (var matchEnum = searcher.Get().GetEnumerator())
                {
    			    if (matchEnum.MoveNext()) // Move to the 1st item.
    			    {
    			        cmdLine = matchEnum.Current["CommandLine"]?.ToString();
    			    }
                }
    		}
    		if (cmdLine == null)
    		{
    			// Not having found a command line implies 1 of 2 exceptions, which the
                // WMI query masked:
    			// An "Access denied" exception due to lack of privileges.
    			// A "Cannot process request because the process (<pid>) has exited."
                // exception due to the process having terminated.
    			// We provoke the same exception again simply by accessing process.MainModule.
    			var dummy = process.MainModule; // Provoke exception.
    		}
    		return cmdLine;
    	}
    }
