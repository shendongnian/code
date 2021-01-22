    try
    {            
    	foreach (System.Diagnostics.Process exe in System.Diagnostics.Process.GetProcesses())   
    	{   
    		if (exe.ProcessName.StartsWith("iexplore"))   
    			exe.Kill();   
    	} 
    }
    catch (Win32Exception e)
    {
    	Console.WriteLine("The process is terminating or could not be terminated.");
    }
    
    catch (InvalidOperationException e)
    {
    	Console.Writeline("The process has already exited.");
    }
    
    catch (Exception e)  // some other exception
    {
    	Console.WriteLine("{0} Exception caught.", e);
    }
