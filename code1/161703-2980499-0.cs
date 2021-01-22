     const UInt32 INFINITE = 0xFFFFFFFF;
     
     // Declare variables
     PROCESS_INFORMATION pi;
     STARTUPINFO si;
     System.IntPtr hToken;
     
     // Create structs
     SECURITY_ATTRIBUTES saThreadAttributes = new SECURITY_ATTRIBUTES();    
     // Now create the process as the user
     if (!CreateProcessAsUser(hToken, String.Empty, commandLine,
     null, saThreadAttributes, false, 0, IntPtr.Zero, 0, si, pi))
     {
     // Throw exception
     throw new Exception("Failed to CreateProcessAsUser");
     }
     WaitForSingleObject(pi.hProcess, (int)INFINITE);
