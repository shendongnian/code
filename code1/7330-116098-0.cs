    foreach ( Process p in System.Diagnostics.Process.GetProcessesByName("winword") )
    {
        try
        {
            p.Kill();
            p.WaitForExit(); // possibly with a timeout
        }
        catch ( Win32Exception winException )
        {
            // process was terminating or can't be terminated - deal with it
        }
        catch ( InvalidOperationException invalidException )
        {
            // process has already exited - might be able to let this one go
         }
    }
