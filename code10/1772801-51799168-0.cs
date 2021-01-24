        // Wait for the process to terminate
        Process process = null;
        try
        {
            process = Process.GetProcessById(pid);
            process.WaitForExit(1000);
        }
        catch (Exception ex)
        {
            // Handle appropriately
        }
        Process.Start(applicationName, "");
